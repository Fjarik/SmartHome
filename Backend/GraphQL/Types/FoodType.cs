using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataService.IServices;
using GraphQL.DataLoader;
using GraphQL.Types;
using SharedLibrary.Enums;

namespace Backend.GraphQL.Types
{
	public class FoodType : ObjectGraphType<Food>
	{
		public FoodType(IFoodService foodService,
						ICategoryService categoryService,
						IDataLoaderContextAccessor dataLoader)
		{
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property");
			Field(x => x.Name, type: typeof(NonNullGraphType<StringGraphType>)).Description("Name of food");

			Field(x => x.CategoryIds, type: typeof(ListGraphType<NonNullGraphType<IntGraphType>>)).Description("Category IDs of food");
			Field(x => x.SideIds, type: typeof(ListGraphType<NonNullGraphType<IntGraphType>>)).Description("Side dish IDs of food");
			Field(x => x.Type, type: typeof(NonNullGraphType<FoodTypeEnum>)).Description("Type of food");
			Field(x => x.GlutenFree, type: typeof(NonNullGraphType<BooleanGraphType>)).Description("Is gluten free");

			Field<ListGraphType<NonNullGraphType<CategoryType>>, List<Category>>("categories")
				.Resolve(ctx => categoryService.GetByIds(ctx.Source.CategoryIds))
				.Description("Categories of food");
		}
	}
}