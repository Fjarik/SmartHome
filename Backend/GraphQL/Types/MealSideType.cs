using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using GraphQL.Types;

namespace Backend.GraphQL.Types
{
	public class MealSideType : ObjectGraphType<MealSide>
	{
		public MealSideType()
		{
			Field(x => x.MealId, type: typeof(IdGraphType)).Description("Meal id property");
			Field(x => x.SideDishesId, type: typeof(IdGraphType)).Description("Side id property");

			Field(x => x.Meal, type: typeof(MealType)).Description("Meal");
		}
	}
}
