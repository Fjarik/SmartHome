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
using SharedLibrary.Enums;
using FoodType = Backend.GraphQL.Types.FoodType;

namespace Backend.GraphQL.Queries
{
	public class AppQuery : ObjectGraphType
	{
		private readonly IUserService _userService;
		private readonly IFoodService _foodService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IAuthManager _authManager;
		private readonly ICategoryService _categoryService;
		private readonly IMealService _mealService;

		public AppQuery(IUserService userService,
						IHttpContextAccessor httpContextAccessor,
						IAuthManager authManager,
						IFoodService foodService,
						ICategoryService categoryService,
						IMealService mealService)
		{
			_userService = userService;
			_httpContextAccessor = httpContextAccessor;
			_authManager = authManager;
			_foodService = foodService;
			_categoryService = categoryService;
			_mealService = mealService;
			Field<UserType, User>("logged")
				.Resolve(GetLogged);
			Field<ListGraphType<UserType>, List<User>>("users")
				.Resolve(GetUsers);
			Field<ListGraphType<FoodType>, List<Food>>("foods")
				.Argument<ListGraphType<NonNullGraphType<FoodTypeEnum>>, List<FoodTypes>>("types", "Get foods by types")
				.Resolve(GetFoods);
			Field<ListGraphType<CategoryType>, List<Category>>("categories")
				.Resolve(ctx => this._categoryService.GetAll());
			Field<ListGraphType<MealType>, List<Meal>>("meals")
				.Argument<DateGraphType, DateTime>("date", "Get meals by date")
				.Resolve(GetMeals);
		}

		private User GetLogged(ResolveFieldContext<object> ctx)
		{
			if (!(this._authManager.Authorize(_httpContextAccessor, ctx))) {
				return null;
			}

			var token = this._httpContextAccessor.GetToken();
			var res = this._authManager.GetLogged(token, ctx);
			if (!res.IsSuccess) {
				return null;
			}

			return res.Content;
		}

		private List<User> GetUsers(ResolveFieldContext<object> ctx)
		{
			if (!(this._authManager.Authorize(_httpContextAccessor, ctx))) {
				return null;
			}
			return this._userService.GetAll();
		}

		private List<Food> GetFoods(ResolveFieldContext<object> ctx)
		{
			//if (!(this._authManager.Authorize(_httpContextAccessor, ctx))) {
			//	return null;
			//}

			var types = ctx.GetArgument("types", new List<FoodTypes>());
			if (!types.Any()) {
				return this._foodService.GetAll();
			}
			return this._foodService.GetByTypes(types.ToArray());
		}

		private List<Meal> GetMeals(ResolveFieldContext<object> ctx)
		{
			if (!(this._authManager.Authorize(_httpContextAccessor, ctx))) {
				return null;
			}

			var date = ctx.GetArgument<DateTime?>("date", null);
			if (date != null) {
				return this._mealService.GetByDate((DateTime) date);
			}
			return this._mealService.GetAll();
		}
	}
}