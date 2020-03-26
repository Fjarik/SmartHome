using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server.Transports.AspNetCore;
using Microsoft.AspNetCore.Http;

namespace Backend.Other.Auth
{
	public class GraphQLUserContextBuilder : IUserContextBuilder
	{
		public Task<object> BuildUserContext(HttpContext httpContext)
		{
			if (httpContext is null) {
				throw new ArgumentNullException(nameof(httpContext));
			}

			return Task.FromResult<object>(new GraphQLUserContext() {User = httpContext.User});
		}
	}
}