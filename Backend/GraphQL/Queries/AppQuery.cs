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
using FoodType = Backend.GraphQL.Types.FoodType;

namespace Backend.GraphQL.Queries
{
	public class AppQuery : ObjectGraphType
	{
		private readonly IUserService _userService;
		private readonly IFoodService _foodService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IAuthManager _authManager;

		public AppQuery(IUserService userService,
						IHttpContextAccessor httpContextAccessor,
						IAuthManager authManager,
						IFoodService foodService)
		{
			_userService = userService;
			_httpContextAccessor = httpContextAccessor;
			_authManager = authManager;
			_foodService = foodService;
			FieldAsync<UserType, User>("logged", resolve: GetLogged);
			FieldAsync<ListGraphType<UserType>, List<User>>("users", resolve: GetUsers);
			FieldAsync<ListGraphType<FoodType>, List<Food>>(
				"foods", resolve: ctx => this._foodService.GetAllAsync(ctx.CancellationToken));
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
			return await this._userService.GetAllAsync(ctx.CancellationToken);
		}
	}
}