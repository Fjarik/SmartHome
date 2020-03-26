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
		Task<bool> AuthorizeAsync(IHttpContextAccessor httpContext, ResolveFieldContext<object> ctx);
		Task<AuthUser> LoginAsync(string googleToken, ResolveFieldContext<object> ctx);
		Task<HomeResult<User>> GetLoggedAsync(string token, ResolveFieldContext<object> ctx);
		Task<bool> VerifyTokenAsync(string token, CancellationToken cancellationToken);
	}
}