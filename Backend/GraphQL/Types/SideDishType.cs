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
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property");
			Field(x => x.Name, type: typeof(StringGraphType)).Description("Name of side dish");
			Field(x => x.Description, type: typeof(StringGraphType)).Description("Description");
			Field(x => x.GlutenFree, type: typeof(BooleanGraphType)).Description("Is gluten free");
		}
	}
}