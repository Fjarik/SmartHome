using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.GraphQL.Types;
using Backend.IManagers;
using Backend.Other;
using DataAccess.Models;
using DataService.IServices;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;

namespace Backend.GraphQL.Queries
{
	public class AppQuery : ObjectGraphType
	{
		private readonly IUserService _userService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IAuthManager _authManager;

		public AppQuery(IUserService userService, IHttpContextAccessor httpContextAccessor, IAuthManager authManager)
		{
			_userService = userService;
			_httpContextAccessor = httpContextAccessor;
			_authManager = authManager;
			FieldAsync<UserType, User>("logged", resolve: GetLogged);
			FieldAsync<ListGraphType<UserType>, List<User>>("Users", resolve: GetUsers);
		}

		private async Task<User> GetLogged(ResolveFieldContext<object> ctx)
		{
			if (!(await this._authManager.AuthorizeAsync(_httpContextAccessor, ctx))) {
				return null;
			}

			var token = this._httpContextAccessor.GetToken();
			var res = await this._authManager.GetLoggedAsync(token, ctx);
			if (!res.IsSuccess) {
				return null;
			}

			return res.Content;
		}

		private async Task<List<User>> GetUsers(ResolveFieldContext<object> ctx)
		{
			if (!(await this._authManager.AuthorizeAsync(_httpContextAccessor, ctx))) {
				return null;
			}
			return await this._userService.GetAllAsync();
		}
	}
}