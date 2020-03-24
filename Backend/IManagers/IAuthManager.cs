using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Objects;

namespace Backend.IManagers
{
	public interface IAuthManager
	{
		Task<bool> AuthorizeAsync(IHttpContextAccessor httpContext, ResolveFieldContext<object> ctx);
		Task<User> LoginAsync(string googleToken, ResolveFieldContext<object> ctx);
		Task<HomeResult<User>> GetLoggedAsync(string token, ResolveFieldContext<object> ctx);
		Task<bool> VerifyTokenAsync(string token);
	}
}