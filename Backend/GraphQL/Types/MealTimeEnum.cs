using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using SharedLibrary.Enums;

namespace Backend.GraphQL.Types
{
	public class MealTimeEnum : EnumerationGraphType<MealTimes>
	{
		public MealTimeEnum()
		{
			this.Name = nameof(MealTimeEnum);
			this.Description = "Meal time enum";
		}
	}
}