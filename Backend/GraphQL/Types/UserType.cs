using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using GraphQL.Types;

namespace Backend.GraphQL.Types
{
	public class UserType : ObjectGraphType<User>
	{
		public UserType()
		{
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property.");
			Field(x => x.Name, type: typeof(StringGraphType)).Description("Full name.");
		}
	}
}
