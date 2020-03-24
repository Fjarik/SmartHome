using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using GraphQL.Types;

namespace Backend.GraphQL.Types
{
	public class MealType : ObjectGraphType<Meal>
	{
		public MealType()
		{
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property");
			Field(x => x.CookedById, type: typeof(IdGraphType)).Description("Cooked by id property");
			Field(x => x.FoodId, type: typeof(IdGraphType)).Description("Food id property");
			Field(x => x.TypeId, type: typeof(IdGraphType)).Description("Type id property");
			Field(x => x.Date, type: typeof(DateGraphType)).Description("Name of food");

			Field(x => x.CookedBy, type: typeof(UserType)).Description("Cooked by user");
			Field(x => x.Food, type: typeof(FoodType)).Description("Food");
			Field(x => x.Type, type: typeof(MealTypeType)).Description("Meal type");
		}
	}
}
