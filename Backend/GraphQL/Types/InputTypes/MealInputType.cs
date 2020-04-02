﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using SharedLibrary.Objects;

namespace Backend.GraphQL.Types.InputTypes
{
	public class MealInputType : InputObjectGraphType<MealInput>
	{
		public MealInputType()
		{
			Name = "MealInput";
			Field(x => x.CookedById, type: typeof(NonNullGraphType<IdGraphType>));
			Field(x => x.FoodId, type: typeof(NonNullGraphType<IdGraphType>));
			Field(x => x.Type, type: typeof(NonNullGraphType<MealTypeEnum>));
			Field(x => x.Date, type: typeof(NonNullGraphType<DateGraphType>));
		}
	}
}