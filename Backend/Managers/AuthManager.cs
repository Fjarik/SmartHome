using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.IManagers;
using Backend.Other;
using DataAccess.Models;
using DataAccess.Other;
using DataService.IServices;
using Google.Apis.Oauth2.v2.Data;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using SharedLibrary.Enums;
using SharedLibrary.Objects;

namespace Backend.Managers
{
	public class AuthManager : IAuthManager
	{
		private readonly IAuthService _authService;
		private readonly IUserService _userService;
		private readonly ITokenService _tokenService;
		private readonly IWebHostEnvironment _environment;

		public AuthManager(IAuthService authService,
						   IUserService userService,
						   ITokenService tokenService,
						   IWebHostEnvironment environment)
		{
			_authService = authService;
			_userService = userService;
			_tokenService = tokenService;
			_environment = environment;
		}

#region Validation

		public string GetToken(IHttpContextAccessor httpContext)
		{
			return httpContext.GetToken();
		}

		public bool Authorize(IHttpContextAccessor httpContext, ResolveFieldContext<object> ctx)
		{
			var token = this.GetToken(httpContext);
			if (string.IsNullOrWhiteSpace(token)) {
				ctx.Errors.Add(new ExecutionError("You are not logged"));
				return false;
			}
			var res = this.VerifyToken(token);
			if (!res.IsSuccess) {
				switch (res.Status) {
					case StatusCode.SeeException:
						ctx.Errors.Add(new ExecutionError("Check exception", res.Exception));
						break;
					case StatusCode.Expired:
						ctx.Errors.Add(new ExecutionError("Token is expired"));
						break;
					default:
						ctx.Errors.Add(new ExecutionError(res.GetStatusMessage()));
						break;
				}
				return false;
			}
			return true;
		}

		public HomeResult<bool> VerifyToken(string token)
		{
			var res = this._tokenService.ValidateToken(token);
			if (!res.IsSuccess) {
				return res;
			}
			return this._tokenService.IsValid(token);
		}

#endregion

#region Refresh

		public AuthToken RefreshToken(string oldToken, string refreshToken, ResolveFieldContext<object> ctx,
									  IHttpContextAccessor httpContext)
		{
			var oldRes = this._tokenService.ValidateToken(oldToken, false);
			if (!oldRes.IsSuccess) {
				ctx.Errors.Add(new ExecutionError("Old token is not valid"));
				return null;
			}

			var old = this._tokenService.GetByToken(oldToken);
			if (old == null) {
				ctx.Errors.Add(new ExecutionError("Old token not found"));
				return null;
			}

			var del = this._tokenService.Delete(oldToken);
			if (!del) {
				ctx.Errors.Add(new ExecutionError("Old token was not deleted"));
			}

			return this.RefreshToken(old, refreshToken, ctx, httpContext);
		}

		private AuthToken RefreshToken(Token old, string refreshToken, ResolveFieldContext<object> ctx,
									   IHttpContextAccessor httpContext)
		{
			if (old.RefreshToken != refreshToken) {
				ctx.Errors.Add(new ExecutionError("Refresh token is not valid"));
				return null;
			}

			var uRes = this._userService.GetById(old.UserId);
			if (!uRes.IsSuccess) {
				ctx.Errors.Add(new ExecutionError("User: " + uRes.GetStatusMessage()));
				return null;
			}

			return this.RefreshToken(uRes.Content, ctx, httpContext);
		}

		private AuthToken RefreshToken(User u, ResolveFieldContext<object> ctx, IHttpContextAccessor httpContext)
		{
			var auth = this.Login(u, ctx, httpContext);
			if (auth == null) {
				ctx.Errors.Add(new ExecutionError("Could not login"));
				return null;
			}

			return auth.AuthToken;
		}

#endregion

		public HomeResult<User> GetLogged(string token, ResolveFieldContext<object> ctx)
		{
			if (string.IsNullOrWhiteSpace(token)) {
				ctx.Errors.Add(new ExecutionError("You are not logged"));
				return null;
			}
			var id = this._tokenService.GetUserId(token);
			if (id < 1) {
				ctx.Errors.Add(new ExecutionError("User not found"));
				return null;
			}
			return this._userService.GetById(id);
		}

#region Login

		public AuthUser Login(string googleToken, ResolveFieldContext<object> ctx, IHttpContextAccessor httpContext)
		{
			Userinfo userInfo;
			try {
				userInfo = _authService.GetGoogleUser(googleToken);
			} catch {
				if (_environment.IsDevelopment()) {
					throw;
				}
				ctx.Errors.Add(new ExecutionError("Google token is not valid"));
				return null;
			}
			if (userInfo == null) {
				return null;
			}
			var email = userInfo.Email;
			var googleId = userInfo.Id;
			var firstname = userInfo.GivenName;
			var lastname = userInfo.FamilyName;

			return this.LoginOrRegister(email, googleId, firstname, lastname, ctx, httpContext);
		}

		private AuthUser LoginOrRegister(string email, string googleId,
										 string firstname, string lastname,
										 ResolveFieldContext<object> ctx,
										 IHttpContextAccessor httpContext)
		{
			if (string.IsNullOrWhiteSpace(email) ||
				string.IsNullOrWhiteSpace(googleId) ||
				string.IsNullOrWhiteSpace(firstname) ||
				string.IsNullOrWhiteSpace(lastname)) {
				return null;
			}

			var exists = _userService.Exists(googleId);
			HomeResult<User> res;
			if (exists) {
				res = _userService.GetByGoogleId(googleId);
			} else {
				res = _userService.Register(googleId, email, firstname, lastname);
			}

			if (!res.IsSuccess) {
				return null;
			}

			var u = res.Content;
			if (u.Email != email) {
				u.Email = email;
				_userService.SaveUser(u);
			}

			return this.Login(u, ctx, httpContext);
		}

		private AuthUser Login(User u,
							   ResolveFieldContext<object> ctx,
							   IHttpContextAccessor httpContext)
		{
			var token = _tokenService.GetToken(u);
			if (string.IsNullOrWhiteSpace(token.AccessToken)) {
				ctx.Errors.Add(new ExecutionError("Could not generate token"));
				return null;
			}

			token = _tokenService.RegisterToken(token);
			if (token == null) {
				ctx.Errors.Add(new ExecutionError("Could not register token"));
				return null;
			}
			if (string.IsNullOrWhiteSpace(token.AccessToken)) {
				ctx.Errors.Add(new ExecutionError("Token is too long"));
				return null;
			}

			httpContext.CreateTokenCookie(token.AccessToken);

			return new AuthUser(u, token);
		}

#endregion

		public bool Logout(string token, bool everywhere = false)
		{
			if (string.IsNullOrWhiteSpace(token)) {
				return false;
			}
			if (!everywhere) {
				return this._tokenService.Delete(token);
			}

			var userId = this._tokenService.GetUserId(token);

			return this._tokenService.DeleteByUserId(userId);
		}
	}
}