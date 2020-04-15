using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using DataService.IServices;
using GraphQL;
using GraphQL.Types;
using SharedLibrary.Interfaces;

namespace Backend.GraphQL.Types
{
	public class MealType : ObjectGraphType<Meal>
	{
		private readonly IMealService _mealService;
		private readonly IFoodService _foodService;

		public MealType(ICategoryService categoryService,
						IFoodService foodService,
						IMealService mealService)
		{
			_foodService = foodService;
			_mealService = mealService;
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property");
			Field(x => x.Date, type: typeof(NonNullGraphType<DateGraphType>)).Description("Name of food");
			Field(x => x.Type, type: typeof(NonNullGraphType<MealTypeEnum>)).Description("Meal type");
			Field(x => x.Time, type: typeof(NonNullGraphType<MealTimeEnum>)).Description("Meal time");

			Field(x => x.OriginalMealId, type: typeof(IdGraphType), nullable: true).Description("Original meal id");
			Field(x => x.SoupId, type: typeof(IdGraphType), nullable: true).Description("Id of soup property");
			Field(x => x.FoodId, type: typeof(IdGraphType), nullable: true).Description("Id of main food property");
			Field(x => x.SideId, type: typeof(IdGraphType), nullable: true).Description("Id of side dish property");

			Field(x => x.CategoryIds, type: typeof(ListGraphType<NonNullGraphType<IntGraphType>>))
				.Description("Categories of food");

			Field<MealType, Meal>("originalmeal")
				.Resolve(GetOriginalMeal)
				.Description("Original meal");
			Field<FoodType, Food>("soup")
				.Resolve(GetSoup)
				.Description("Soup");
			Field<FoodType, Food>("food")
				.Resolve(GetFood)
				.Description("Food");
			Field<FoodType, Food>("sidedish")
				.Resolve(GetSideDish)
				.Description("Side dish");

			Field<ListGraphType<NonNullGraphType<CategoryType>>, List<Category>>("categories")
				.Resolve(ctx => categoryService.GetByIds(ctx.Source.CategoryIds))
				.Description("Categories of meal");
		}

		private Meal GetOriginalMeal(ResolveFieldContext<Meal> ctx)
		{
			return this.GetById(ctx, x => x.OriginalMealId, _mealService);
		}

		private Food GetSideDish(ResolveFieldContext<Meal> ctx)
		{
			return this.GetById(ctx, x => x.SideId, _foodService);
		}

		private Food GetFood(ResolveFieldContext<Meal> ctx)
		{
			return this.GetById(ctx, x => x.FoodId, _foodService);
		}

		private Food GetSoup(ResolveFieldContext<Meal> ctx)
		{
			return this.GetById(ctx, x => x.SoupId, _foodService);
		}

		private TOutEntity GetById<TInEntity, TOutEntity>(ResolveFieldContext<TInEntity> ctx,
														  Func<TInEntity, int?> getId,
														  IBaseService<TOutEntity, IBaseRepository<TOutEntity>> service)
			where TOutEntity : class, IDbEntity
			where TInEntity : class, IDbEntity
		{
			int? id = getId(ctx.Source);
			if (id == null) {
				return null;
			}
			var res = service.GetById((int) id);
			if (!res.IsSuccess) {
				ctx.Errors.Add(new ExecutionError(res.GetStatusMessage()));
				return null;
			}
			return res.Content;
		}
	}
}