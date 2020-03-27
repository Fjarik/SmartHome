using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using SharedLibrary.Enums;

namespace Backend.GraphQL.Types
{
	public class FoodTypeEnum : EnumerationGraphType<FoodTypes>
	{
		public FoodTypeEnum()
		{
			this.Name = nameof(FoodTypeEnum);
			this.Description = "Food enum types";
		}
	}
}