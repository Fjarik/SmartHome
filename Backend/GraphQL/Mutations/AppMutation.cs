using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.GraphQL.Types;
using DataAccess.Models;
using GraphQL.Types;

namespace Backend.GraphQL.Mutations
{
	public class AppMutation : ObjectGraphType
	{
		public AppMutation()
		{
			Field<UserType>("Login", resolve: (ctx) => new User());
		}
	}
}