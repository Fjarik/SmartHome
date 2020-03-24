using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using GraphQL.Types;

namespace Backend.GraphQL.Types
{
	public class FoodCategoryType : ObjectGraphType<FoodCategory>
	{
		public FoodCategoryType()
		{
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property");
			Field(x => x.Name, type: typeof(StringGraphType)).Description("Name of food category");
			Field(x => x.Description, type: typeof(StringGraphType)).Description("Description of food category");

			Field(x => x.Foods, type: typeof(FoodType)).Description("Foods");
		}
	}
}
