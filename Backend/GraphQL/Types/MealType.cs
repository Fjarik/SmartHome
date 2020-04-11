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
		private readonly ISideDishService _sideDishService;
		private readonly IFoodService _foodService;

		public MealType(ICategoryService categoryService,
						ISideDishService sideDishService,
						IFoodService foodService,
						IMealService mealService)
		{
			_sideDishService = sideDishService;
			_foodService = foodService;
			_mealService = mealService;
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property");
			Field(x => x.OriginalMealId, type: typeof(IdGraphType), nullable: true).Description("Original meal id");
			Field(x => x.FoodId, type: typeof(NonNullGraphType<IdGraphType>)).Description("Food id property");
			Field(x => x.Date, type: typeof(NonNullGraphType<DateGraphType>)).Description("Name of food");
			Field(x => x.CategoryIds, type: typeof(ListGraphType<IntGraphType>)).Description("Categories of food");
			Field(x => x.Type, type: typeof(NonNullGraphType<MealTypeEnum>)).Description("Meal type");

			Field<MealType, Meal>("originalmeal")
				.Resolve(GetOriginalMeal)
				.Description("Original meal");
			Field<SideDishType, SideDish>("sidedish")
				.Resolve(GetSideDish)
				.Description("Side dish");
			Field<NonNullGraphType<FoodType>, Food>("food")
				.Resolve(GetFood)
				.Description("Food");

			Field<ListGraphType<CategoryType>, List<Category>>("categories")
				.Resolve(ctx => categoryService.GetByIds(ctx.Source.CategoryIds))
				.Description("Categories of meal");
		}

		private Meal GetOriginalMeal(ResolveFieldContext<Meal> ctx)
		{
			return this.GetById(ctx, x => x.OriginalMealId, _mealService);
		}

		private SideDish GetSideDish(ResolveFieldContext<Meal> ctx)
		{
			return this.GetById(ctx, x => x.SideId, _sideDishService);
		}

		private Food GetFood(ResolveFieldContext<Meal> ctx)
		{
			return this.GetById(ctx, x => x.FoodId, _foodService);
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