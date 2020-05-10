using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Other;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Objects;

namespace Backend.IManagers
{
	public interface IAuthManager
	{
		string GetToken(IHttpContextAccessor httpContext);
		bool Authorize(IHttpContextAccessor httpContext, ResolveFieldContext<object> ctx);
		HomeResult<bool> VerifyToken(string token);

		AuthToken RefreshToken(string oldToken, string refreshToken, ResolveFieldContext<object> ctx, IHttpContextAccessor httpContext);

		HomeResult<User> GetLogged(string token, ResolveFieldContext<object> ctx);
		AuthUser Login(string googleToken, ResolveFieldContext<object> ctx, IHttpContextAccessor httpContext);
		bool Logout(string token, bool everywhere = false);
	}
}