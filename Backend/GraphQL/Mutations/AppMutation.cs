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
			FieldAsync<AuthUserType, AuthUser>("Login",
											   arguments: new
												   QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> {
													   Name = "googleToken"
												   }),
											   resolve: this.LoginAsync);
		}

		private async Task<AuthUser> LoginAsync(ResolveFieldContext<object> ctx)
		{
			var googleToken = ctx.GetArgument<string>("googleToken");

			if (string.IsNullOrWhiteSpace(googleToken)) {
				ctx.Errors.Add(new ExecutionError("Google token is empty"));
				return null;
			}
			return await _authManager.LoginAsync(googleToken, ctx);
		}
	}
}