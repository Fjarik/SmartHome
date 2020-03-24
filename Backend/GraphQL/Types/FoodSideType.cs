using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using GraphQL.Types;

namespace Backend.GraphQL.Types
{
	public class FoodSideType : ObjectGraphType<FoodSide>
	{
		public FoodSideType()
		{
			Field(x => x.FoodId, type: typeof(IdGraphType)).Description("Food id property");
			Field(x => x.SideId, type: typeof(IdGraphType)).Description("Side id property");

			Field(x => x.Food, type: typeof(FoodType)).Description("Food");
		}
	}
}
