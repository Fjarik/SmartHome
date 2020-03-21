using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.GraphQL.Types;
using DataAccess.Models;
using DataService.IServices;
using GraphQL.Types;

namespace Backend.GraphQL.Queries
{
	public class AppQuery : ObjectGraphType
	{
		public AppQuery(IUserService userService)
		{
			FieldAsync<ListGraphType<UserType>>("Users", resolve: (async context => await userService.GetAllAsync()));
		}
	}
}