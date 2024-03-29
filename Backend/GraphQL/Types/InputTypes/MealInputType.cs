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
			Field(x => x.Date, type: typeof(NonNullGraphType<DateGraphType>));
			Field(x => x.Type, type: typeof(NonNullGraphType<MealTypeEnum>));
			Field(x => x.Time, type: typeof(NonNullGraphType<MealTimeEnum>));
			Field(x => x.FoodId, type: typeof(IdGraphType), nullable: true);
			Field(x => x.SoupId, type: typeof(IdGraphType), nullable: true);
			Field(x => x.SideDishId, type: typeof(IdGraphType), nullable: true);
			Field(x => x.OriginalMealId, type: typeof(IdGraphType), nullable: true);
		}
	}
}