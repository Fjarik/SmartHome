using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataService.IServices;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace Backend.GraphQL.Types
{
	public class FoodType : ObjectGraphType<Food>
	{
		public FoodType(IFoodService foodService,
						ICategoryService categoryService,
						IDataLoaderContextAccessor dataLoader)
		{
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property");
			Field(x => x.TypeId, type: typeof(IdGraphType)).Description("Type id property");
			Field(x => x.Name, type: typeof(StringGraphType)).Description("Name of food");

			Field(x => x.Type, type: typeof(FoodTypeType)).Description("Type of food");
			Field(x => x.CategoryIds, type: typeof(ListGraphType<IntGraphType>)).Description("Categories of food");

			Field<ListGraphType<CategoryType>, List<Category>>("categories")
				.Resolve(ctx => categoryService.GetByIds(ctx.Source.CategoryIds.ToList()))
				.Description("Categories of food");

			//Field<ListGraphType<CategoryType>, List<Category>>("categories")
			//	//.Resolve(x => x.Source.FoodCategories.Select(y => y.Category).ToList())
			//	.ResolveAsync(async x => {
			//		var loader = dataLoader.Context
			//							   .GetOrAddCollectionBatchLoader<int, Category>("",
			//																			 y =>
			//																				 categoryService
			//																					 .GetByIds(
			//																						 y,
			//																						 x.CancellationToken));
			//		var res = await loader.LoadAsync(x.Source.Id);

			//		return res.ToList();
			//	})
			//	.Description("Categories of food");
		}
	}
}