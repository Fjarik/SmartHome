using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using SharedLibrary.Objects;

namespace Backend.GraphQL.Types.InputTypes
{
	public class FoodInputType : InputObjectGraphType<FoodInput>
	{
		public FoodInputType()
		{
			Name = "FoodInput";
			Field(x => x.Name, type: typeof(NonNullGraphType<StringGraphType>));
			Field(x => x.Type, type: typeof(NonNullGraphType<FoodTypeEnum>));
			Field(x => x.Categories, type: typeof(ListGraphType<IdGraphType>));
			Field(x => x.GlutenFree, type: typeof(BooleanGraphType), nullable: true);
		}
	}
}