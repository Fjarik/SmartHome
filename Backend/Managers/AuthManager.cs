﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.IManagers;
using DataAccess.Models;
using DataService.IServices;
using Google.Apis.Oauth2.v2.Data;
using GraphQL.Types;
using SharedLibrary.Objects;

namespace Backend.Managers
{
	public class AuthManager : IAuthManager
	{
		private readonly IAuthService _authService;
		private readonly IUserService _userService;
		private readonly ITokenService _tokenService;

		public AuthManager(IAuthService authService,
						   IUserService userService, ITokenService tokenService)
		{
			_authService = authService;
			_userService = userService;
			_tokenService = tokenService;
		}

		public async Task<User> LoginAsync(string googleToken, ResolveFieldContext<object> ctx)
		{
			Userinfoplus userInfo;
			try {
				userInfo = await _authService.GetGoogleUserAsync(googleToken);
			} catch (Exception e) {
				Console.WriteLine(e);
				throw;
			}
			if (userInfo == null) {
				return null;
			}
			var email = userInfo.Email;
			var googleId = userInfo.Id;
			var firstname = userInfo.GivenName;
			var lastname = userInfo.FamilyName;

			return await this.LoginAsync(email, googleId, firstname, lastname, ctx);
		}

		private async Task<User> LoginAsync(string email, string googleId, string firstname, string lastname,
											ResolveFieldContext<object> ctx)
		{
			if (string.IsNullOrWhiteSpace(email) ||
				string.IsNullOrWhiteSpace(googleId) ||
				string.IsNullOrWhiteSpace(firstname) ||
				string.IsNullOrWhiteSpace(lastname)) {
				return null;
			}

			var exists = await _userService.ExistsAsync(googleId);
			HomeResult<User> res;
			if (exists) {
				res = await _userService.GetByGoogleIdAsync(googleId);
			} else {
				res = await _userService.RegisterAsync(googleId, email, firstname, lastname);
			}

			if (!res.IsSuccess) {
				return null;
			}

			var u = res.Content;
			if (u.Email != email) {
				u.Email = email;
				await _userService.SaveUserAsync(u);
			}

			return await this.LoginAsync(u, ctx);
		}

		private async Task<User> LoginAsync(User u, ResolveFieldContext<object> ctx)
		{
			var token = _tokenService.GetToken(u);
			if (string.IsNullOrWhiteSpace(token.TokenString)) {
				return null;
			}

			token = await _tokenService.RegisterTokenAsync(token);
			if (token == null) {
				return null;
			}
			if (string.IsNullOrWhiteSpace(token.TokenString)) {
				return null;
			}

			u.AuthToken = token.TokenString;

			return u;
		}
	}
}