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
		bool Authorize(IHttpContextAccessor httpContext, ResolveFieldContext<object> ctx);
		AuthUser Login(string googleToken, ResolveFieldContext<object> ctx);
		HomeResult<User> GetLogged(string token, ResolveFieldContext<object> ctx);
		HomeResult<bool> VerifyToken(string token);
		bool Logout(string token, bool everywhere = false);
	}
}