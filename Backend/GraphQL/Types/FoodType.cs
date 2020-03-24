using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using GraphQL.Types;

namespace Backend.GraphQL.Types
{
	public class FoodType : ObjectGraphType<Food>
	{
		public FoodType()
		{
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property");
			Field(x => x.CategoryId, type: typeof(IdGraphType)).Description("Category id property");
			Field(x => x.TypeId, type: typeof(IdGraphType)).Description("Type id property");
			Field(x => x.Name, type: typeof(StringGraphType)).Description("Name of food");

			Field(x => x.Category, type: typeof(FoodCategoryType)).Description("Category of food");
			Field(x => x.Type, type: typeof(FoodTypeType)).Description("Type of food");
		}
	}
}