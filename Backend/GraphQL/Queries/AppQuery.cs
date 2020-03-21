using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.GraphQL.Types;
using DataAccess.Models;
using GraphQL.Types;

namespace Backend.GraphQL.Queries
{
	public class AppQuery : ObjectGraphType
	{
		public AppQuery()
		{
			Field<ListGraphType<UserType>>("Users", resolve: ctx => new List<User>());
		}
	}
}