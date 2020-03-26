using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GraphQL.Authorization;

namespace Backend.Other.Auth
{
	public class GraphQLUserContext : IProvideClaimsPrincipal
	{
		public ClaimsPrincipal User { get; set; }
	}
}