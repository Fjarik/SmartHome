using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.GraphQL.Types;
using Backend.GraphQL.Types.InputTypes;
using Backend.IManagers;
using Backend.Other;
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
		private readonly IFoodService _foodService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AppMutation(IAuthManager authManager,
						   IMealService mealService,
						   IHttpContextAccessor httpContextAccessor,
						   IFoodService foodService)
		{
			_authManager = authManager;
			_mealService = mealService;
			_httpContextAccessor = httpContextAccessor;
			_foodService = foodService;
			Field<AuthUserType, AuthUser>("login")
				.Argument<NonNullGraphType<StringGraphType>>("googleToken", "Google token to login")
				.Resolve(this.Login);
			Field<BooleanGraphType, bool>("logout")
				.Argument<BooleanGraphType>("logoutAll", "Should logout from all devices")
				.Resolve(this.Logout);
			
			// Meal
			Field<MealType, Meal>("createMeal")
				.Argument<NonNullGraphType<MealInputType>>("meal", "Meal to create")
				.Resolve(this.CreateMeal);

			// Food
			Field<FoodType, Food>("createFood")
				.Argument<NonNullGraphType<FoodInputType>>("food", "Food to create")
				.Resolve(this.CreateFood);
			Field<FoodType, Food>("updateFood")
				.Argument<NonNullGraphType<IntGraphType>>("foodId", "Original food ID")
				.Argument<NonNullGraphType<FoodInputType>>("food", "Variables to update")
				.Resolve(this.UpdateFood);
			Field<NonNullGraphType<BooleanGraphType>, bool>("removeFood")
				.Argument<NonNullGraphType<IdGraphType>>("id", "Food to remove")
				.Resolve(this.RemoveFood);
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

		private bool Logout(ResolveFieldContext<object> ctx)
		{
			if (!(this._authManager.Authorize(_httpContextAccessor, ctx))) {
				return false;
			}
			var everywhere = ctx.GetArgument<bool?>("logoutAll") ?? false;

			var t = this._httpContextAccessor.GetToken();

			return this._authManager.Logout(t, everywhere);
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

		private Food CreateFood(ResolveFieldContext<object> ctx)
		{
			if (!(this._authManager.Authorize(_httpContextAccessor, ctx))) {
				return null;
			}

			var input = ctx.GetArgument<FoodInput>("food");

			if (input == null) {
				ctx.Errors.Add(new ExecutionError("Input is empty"));
				return null;
			}

			var res = this._foodService.Create(input);
			if (!res.IsSuccess) {
				ctx.Errors.Add(new ExecutionError(res.GetStatusMessage()));
				return null;
			}

			return res.Content;
		}

		private Food UpdateFood(ResolveFieldContext<object> ctx)
		{
			if (!(this._authManager.Authorize(_httpContextAccessor, ctx))) {
				return null;
			}

			var foodId = ctx.GetArgument<int>("foodId");
			var input = ctx.GetArgument<FoodInput>("food");

			if (input == null) {
				ctx.Errors.Add(new ExecutionError("Input is empty"));
				return null;
			}

			if (foodId < 1) {
				ctx.Errors.Add(new ExecutionError("Food ID is not valid"));
				return null;
			}

			var res = this._foodService.Update(foodId, input);
			if (!res.IsSuccess) {
				ctx.Errors.Add(new ExecutionError(res.GetStatusMessage()));
				return null;
			}

			return res.Content;
		}

		private bool RemoveFood(ResolveFieldContext<object> ctx)
		{
			if (!(this._authManager.Authorize(_httpContextAccessor, ctx))) {
				return false;
			}

			var input = ctx.GetArgument<int>("id");

			if (input < 1) {
				ctx.Errors.Add(new ExecutionError("ID is < 1"));
				return false;
			}

			return this._foodService.Delete(input);
		}
	}
}