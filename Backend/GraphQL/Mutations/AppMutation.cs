using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.GraphQL.Types;
using Backend.GraphQL.Types.InputTypes;
using Backend.IManagers;
using DataAccess.Models;
using DataAccess.Other;
using DataService.IServices;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SharedLibrary.Objects;

namespace Backend.GraphQL.Mutations
{
	public class AppMutation : ObjectGraphType
	{
		private readonly IAuthManager _authManager;
		private readonly IMealService _mealService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AppMutation(IAuthManager authManager,
						   IMealService mealService,
						   IHttpContextAccessor httpContextAccessor)
		{
			_authManager = authManager;
			_mealService = mealService;
			_httpContextAccessor = httpContextAccessor;
			Field<AuthUserType, AuthUser>("Login")
				.Argument<NonNullGraphType<StringGraphType>>("googleToken", "")
				.Resolve(this.Login);
			Field<MealType, Meal>("createMeal")
				.Argument<NonNullGraphType<MealInputType>>("meal", "")
				.Resolve(this.CreateMeal);
		}

		private AuthUser Login(ResolveFieldContext<object> ctx)
		{
			var googleToken = ctx.GetArgument<string>("googleToken");

			if (string.IsNullOrWhiteSpace(googleToken)) {
				ctx.Errors.Add(new ExecutionError("Google token is empty"));
				return null;
			}
			return _authManager.Login(googleToken, ctx);
		}

		private Meal CreateMeal(ResolveFieldContext<object> ctx)
		{
			if (!(this._authManager.Authorize(_httpContextAccessor, ctx))) {
				return null;
			}

			var input = ctx.GetArgument<MealInput>("meal");

			if (input == null) {
				ctx.Errors.Add(new ExecutionError("Input is empty"));
				return null;
			}

			var res = this._mealService.Create(input);
			if (!res.IsSuccess) {
				ctx.Errors.Add(new ExecutionError(res.GetStatusMessage()));
				return null;
			}

			return res.Content;
		}
	}
}