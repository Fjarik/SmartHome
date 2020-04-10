using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataService.IServices;
using GraphQL.Types;

namespace Backend.GraphQL.Types
{
	public class MealType : ObjectGraphType<Meal>
	{
		public MealType(ICategoryService categoryService)
		{
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property");
			Field(x => x.OriginalMealId, type: typeof(IdGraphType), nullable: true).Description("Original meal id");
			Field(x => x.FoodId, type: typeof(IdGraphType)).Description("Food id property");
			Field(x => x.Date, type: typeof(DateGraphType)).Description("Name of food");
			Field(x => x.CategoryIds, type: typeof(ListGraphType<IntGraphType>)).Description("Categories of food");

			Field(x => x.Side, type: typeof(SideDishType)).Description("Side dish");
			Field(x => x.Food, type: typeof(FoodType)).Description("Food");
			Field(x => x.Type, type: typeof(MealTypeEnum)).Description("Meal type");

			Field<ListGraphType<CategoryType>, List<Category>>("categories")
				.Resolve(ctx => categoryService.GetByIds(ctx.Source.CategoryIds))
				.Description("Categories of meal");
		}
	}
}