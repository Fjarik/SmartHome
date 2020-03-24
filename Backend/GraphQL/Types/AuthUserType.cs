using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.GraphQL.Types.Interfaces;
using DataAccess.Other;
using GraphQL.Types;

namespace Backend.GraphQL.Types
{
	public class AuthUserType : ObjectGraphType<AuthUser>
	{
		public AuthUserType()
		{
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property");
			Field(x => x.Firstname, type: typeof(StringGraphType)).Description("Firstname");
			Field(x => x.Lastname, type: typeof(StringGraphType)).Description("Lastname");
			Field(x => x.CreatedAt, type: typeof(DateTimeGraphType)).Description("Created at");

			Field(x => x.AuthToken, type: typeof(StringGraphType)).Description("Token");

			this.Interface<UserInterface>();
		}
	}
}