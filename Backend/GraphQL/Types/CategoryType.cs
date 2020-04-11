using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using GraphQL.Types;

namespace Backend.GraphQL.Types
{
	public class CategoryType : ObjectGraphType<Category>
	{
		public CategoryType()
		{
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property");
			Field(x => x.Name, type: typeof(NonNullGraphType<StringGraphType>)).Description("Name of food category");
			Field(x => x.Description, type: typeof(StringGraphType), nullable: true)
				.Description("Description of food category");
			Field(x => x.FoodIds, type: typeof(ListGraphType<NonNullGraphType<IntGraphType>>)).Description("Food(s) of category");

			//Field<ListGraphType<FoodType>, List<Food>>("Foods")
			//	.Resolve(ctx => ctx.Source.FoodCategories.Select(y => y.Food).ToList())
			//	.Description("Foods");
		}
	}
}