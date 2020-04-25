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
using GraphQL.Execution;
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

			// Account
			Field<AuthUserType, AuthUser>("login")
				.Argument<NonNullGraphType<StringGraphType>, string>("googleToken", "Google token to login")
				.Resolve(this.Login);
			Field<AuthTokenType, AuthToken>("refreshToken")
				.Argument<NonNullGraphType<StringGraphType>, string>("refreshToken", "Refresh token")
				.Resolve(this.RefreshToken);
			Field<NonNullGraphType<BooleanGraphType>, bool>("logout")
				.Argument<BooleanGraphType>("logoutAll", "Should logout from all devices")
				.Resolve(this.Logout);

			// Meal
			Field<MealType, Meal>("createMeal")
				.Argument<NonNullGraphType<MealInputType>>("meal", "Meal to create")
				.Resolve(this.CreateMeal);
			Field<NonNullGraphType<BooleanGraphType>, bool>("removeMeal")
				.Argument<NonNullGraphType<IdGraphType>>("id", "Meal id to remove")
				.Argument<NonNullGraphType<BooleanGraphType>, bool>("incRelated", "Remove related meals")
				.Resolve(this.RemoveMeal);

			// Food
			Field<FoodType, Food>("createFood")
				.Argument<NonNullGraphType<FoodInputType>>("food", "Food to create")
				.Resolve(this.CreateFood);
			Field<FoodType, Food>("updateFood")
				.Argument<NonNullGraphType<IdGraphType>>("foodId", "Original food ID")
				.Argument<NonNullGraphType<FoodInputType>>("food", "Variables to update")
				.Resolve(this.UpdateFood);
			Field<NonNullGraphType<BooleanGraphType>, bool>("removeFood")
				.Argument<NonNullGraphType<IdGraphType>>("id", "Food id to remove")
				.Resolve(this.RemoveFood);
		}

		private AuthUser Login(ResolveFieldContext<object> ctx)
		{
			var googleToken = ctx.GetArgument<string>("googleToken");

			if (string.IsNullOrWhiteSpace(googleToken)) {
				ctx.Errors.Add(new InvalidValueException(nameof(googleToken), "Google token is empty"));
				return null;
			}
			return _authManager.Login(googleToken, ctx);
		}

		private AuthToken RefreshToken(ResolveFieldContext<object> ctx)
		{
			var token = this._authManager.GetToken(_httpContextAccessor);
			if (string.IsNullOrWhiteSpace(token)) {
				ctx.Errors.Add(new InvalidValueException(nameof(token), "Access token is empty"));
				return null;
			}

			var refreshToken = ctx.GetArgument<string>("refreshToken");
			if (string.IsNullOrWhiteSpace(refreshToken)) {
				ctx.Errors.Add(new InvalidValueException(nameof(refreshToken), "Refresh token is empty"));
				return null;
			}

			return this._authManager.RefreshToken(token, refreshToken, ctx);
		}

		private bool Logout(ResolveFieldContext<object> ctx)
		{
			if (!(this._authManager.Authorize(_httpContextAccessor, ctx))) {
				return false;
			}
			var everywhere = ctx.GetArgument("logoutAll", false);

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

		private bool RemoveMeal(ResolveFieldContext<object> ctx)
		{
			if (!(this._authManager.Authorize(_httpContextAccessor, ctx))) {
				return false;
			}

			var mealId = ctx.GetArgument<int>("id");
			var incRelated = ctx.GetArgument<bool>("incRelated");

			if (mealId < 1) {
				ctx.Errors.Add(new ExecutionError("ID is < 1"));
				return false;
			}

			return this._mealService.Remove(mealId, incRelated);
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