using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.GraphQL.Types;
using Backend.IManagers;
using DataAccess.Models;
using DataAccess.Other;
using DataService.IServices;
using GraphQL;
using GraphQL.Types;

namespace Backend.GraphQL.Mutations
{
	public class AppMutation : ObjectGraphType
	{
		private readonly IAuthManager _authManager;

		public AppMutation(IAuthManager authManager)
		{
			_authManager = authManager;
			Field<AuthUserType, AuthUser>("Login")
				.Argument<NonNullGraphType<StringGraphType>>("googleToken", "")
				.Resolve(this.Login);
		}

		private AuthUser Login(ResolveFieldContext<object> ctx)
		{
			var googleToken = ctx.GetArgument<string>("googleToken");

			if (string.IsNullOrWhiteSpace(googleToken)) {
				ctx.Errors.Add(new ExecutionError("Google token is empty"));
				return null;
			}
			return _authManager.Login(googleToken, ctx);
		}
	}
}