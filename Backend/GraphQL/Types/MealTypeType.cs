using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace Backend.GraphQL.Types
{
	public class MealTypeType : ObjectGraphType<DataAccess.Models.MealType>
	{
		public MealTypeType()
		{
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property");
			Field(x => x.Name, type: typeof(StringGraphType)).Description("Name of food type");
			Field(x => x.Description, type: typeof(StringGraphType)).Description("Description of food type");

			Field(x => x.Meals, type: typeof(FoodType)).Description("Meals");
		}
	}
}
