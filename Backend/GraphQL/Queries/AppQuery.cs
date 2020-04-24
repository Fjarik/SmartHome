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
using GraphQL.Execution;
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

		private const int MaxDaysBefore = 5;
		private const int MaxDaysAfter = 5;

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
			Field<ListGraphType<NonNullGraphType<UserType>>, List<User>>("users")
				.Resolve(GetUsers);
			Field<ListGraphType<NonNullGraphType<FoodType>>, List<Food>>("foods")
				.Argument<ListGraphType<NonNullGraphType<FoodTypeEnum>>, List<FoodTypes>>("types", "Get foods by types")
				.Resolve(GetFoods);
			Field<ListGraphType<NonNullGraphType<CategoryType>>, List<Category>>("categories")
				.Resolve(ctx => this._categoryService.GetAll());
			Field<ListGraphType<NonNullGraphType<MealType>>, List<Meal>>("meals")
				.Argument<NonNullGraphType<IntGraphType>, int>("daysBefore", "How many days to select before DATE",
															   1)
				.Argument<NonNullGraphType<IntGraphType>, int>("daysAfter", "How many days to select after DATE", 5)
				.Argument<NonNullGraphType<DateGraphType>, DateTime>("date", "Get meals by date", DateTime.Today)
				.Resolve(GetMeals);
			Field<ListGraphType<NonNullGraphType<MealType>>, List<Meal>>("allMeals")
				.Resolve(GetAllMeals);
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
				return new List<Meal>();
			}

			var date = ctx.GetArgument("date", DateTime.Today);
			var daysBefore = ctx.GetArgument("daysBefore", 1);
			if (daysBefore < 0) {
				ctx.Errors.Add(new InvalidValueException(nameof(daysBefore), "Is less than 0"));
				return new List<Meal>();
			}
			if (daysBefore > MaxDaysBefore) {
				ctx.Errors.Add(new InvalidValueException(nameof(daysBefore), "Maximum is 5"));
				return new List<Meal>();
			}

			var daysAfter = ctx.GetArgument("daysAfter", 5);
			if (daysAfter < 0) {
				ctx.Errors.Add(new InvalidValueException(nameof(daysAfter), "Is less than 0"));
				return new List<Meal>();
			}
			if (daysAfter > MaxDaysAfter) {
				ctx.Errors.Add(new InvalidValueException(nameof(daysAfter), "Maximum is 5"));
				return new List<Meal>();
			}

			return this._mealService.GetByDate(date, daysBefore, daysAfter);
		}

		private List<Meal> GetAllMeals(ResolveFieldContext<object> ctx)
		{
			if (!(this._authManager.Authorize(_httpContextAccessor, ctx))) {
				return null;
			}

			return this._mealService.GetAll();
		}
	}
}