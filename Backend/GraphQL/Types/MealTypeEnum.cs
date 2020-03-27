using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using SharedLibrary.Enums;

namespace Backend.GraphQL.Types
{
	public class MealTypeEnum : EnumerationGraphType<MealTypes>
	{
		public MealTypeEnum()
		{
			this.Name = nameof(MealTypeEnum);
			this.Description = "Meal enum types";
		}
	}
}