using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using GraphQL.Types;

namespace Backend.GraphQL.Types
{
	public class SideDishType : ObjectGraphType<SideDish>
	{
		public SideDishType()
		{
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property");
			Field(x => x.Name, type: typeof(NonNullGraphType<StringGraphType>)).Description("Name of side dish");
			Field(x => x.Description, type: typeof(StringGraphType), nullable: true).Description("Description");
			Field(x => x.GlutenFree, type: typeof(NonNullGraphType<BooleanGraphType>)).Description("Is gluten free");
		}
	}
}