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

		public bool Authorize(IHttpContextAccessor httpContext, ResolveFieldContext<object> ctx)
		{
			var token = httpContext.GetToken();
			if (string.IsNullOrWhiteSpace(token)) {
				ctx.Errors.Add(new ExecutionError("You are not logged"));
				return false;
			}
			var isValid = this.VerifyToken(token);
			if (!isValid) {
				ctx.Errors.Add(new ExecutionError("Token is not valid"));
				return false;
			}
			return true;
		}

		public AuthUser Login(string googleToken, ResolveFieldContext<object> ctx)
		{
			Userinfoplus userInfo;
			try {
				userInfo = _authService.GetGoogleUser(googleToken);
			} catch (Exception e) {
				Console.WriteLine(e);
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

			return this.Login(email, googleId, firstname, lastname, ctx);
		}

		public HomeResult<User> GetLogged(string token, ResolveFieldContext<object> ctx)
		{
			if (string.IsNullOrWhiteSpace(token)) {
				return null;
			}
			var id = this._tokenService.GetUserId(token);
			if (id < 1) {
				return null;
			}
			return this._userService.GetById(id);
		}

		public bool VerifyToken(string token)
		{
			var res = this._tokenService.ValidateToken(token);
			if (!res) {
				return false;
			}
			return this._tokenService.IsValid(token);
		}

		private AuthUser Login(string email, string googleId, string firstname, string lastname,
							   ResolveFieldContext<object> ctx)
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

			return this.Login(u, ctx);
		}

		private AuthUser Login(User u, ResolveFieldContext<object> ctx)
		{
			var token = _tokenService.GetToken(u);
			if (string.IsNullOrWhiteSpace(token.TokenString)) {
				return null;
			}

			token = _tokenService.RegisterToken(token);
			if (token == null) {
				return null;
			}
			if (string.IsNullOrWhiteSpace(token.TokenString)) {
				return null;
			}
			var authUser = new AuthUser(u) {
				AuthToken = token.TokenString
			};

			return authUser;
		}
	}
}