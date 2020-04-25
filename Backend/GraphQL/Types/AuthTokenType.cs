using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using SharedLibrary.Objects;

namespace Backend.GraphQL.Types
{
	public class AuthTokenType : ObjectGraphType<AuthToken>
	{
		public AuthTokenType()
		{
			Field(x => x.AccessToken, false, typeof(NonNullGraphType<StringGraphType>)).Description("Access token");
			Field(x => x.Expiration, false, typeof(NonNullGraphType<DateTimeGraphType>)).Description("Expiration of token");
			Field(x => x.RefreshToken, false, typeof(NonNullGraphType<StringGraphType>)).Description("Refresh token");
		}
	}
}