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
			Field(x => x.Id, false, typeof(NonNullGraphType<IdGraphType>)).Description("Id property");
			Field(x => x.Firstname, false, typeof(NonNullGraphType<StringGraphType>)).Description("Firstname");
			Field(x => x.Lastname, false, typeof(NonNullGraphType<StringGraphType>)).Description("Lastname");
			Field(x => x.CreatedAt, false, typeof(NonNullGraphType<DateTimeGraphType>)).Description("Created at");

			Field(x => x.AuthToken, false, typeof(NonNullGraphType<AuthTokenType>)).Description("Token");

			this.Interface<UserInterface>();
		}
	}
}