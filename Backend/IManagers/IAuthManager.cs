using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using GraphQL.Types;

namespace Backend.IManagers
{
	public interface IAuthManager
	{
		Task<User> LoginAsync(string googleToken, ResolveFieldContext<object> ctx);
		string GetToken(User u);
	}
}