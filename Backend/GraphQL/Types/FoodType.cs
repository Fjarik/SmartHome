﻿using System;
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
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property");
			Field(x => x.Name, type: typeof(StringGraphType)).Description("Name of food");

			Field(x => x.CategoryIds, type: typeof(ListGraphType<IntGraphType>)).Description("Categories of food");
			Field(x => x.Type, type: typeof(FoodTypeEnum)).Description("Type of food");

			Field<ListGraphType<CategoryType>, List<Category>>("categories")
				.Resolve(ctx => categoryService.GetByIds(ctx.Source.CategoryIds))
				.Description("Categories of food");
		}
	}
}