using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.GraphQL.Mutations;
using Backend.GraphQL.Queries;
using GraphQL;
using GraphQL.Types;

namespace Backend.GraphQL.Schemas
{
	public class AppSchema : Schema
	{
		public AppSchema(IDependencyResolver resolver) : base(resolver)
		{
			this.Query = resolver.Resolve<AppQuery>();
			this.Mutation = resolver.Resolve<AppMutation>();
		}
	}
}
