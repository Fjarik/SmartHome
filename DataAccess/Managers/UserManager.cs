using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.IManagers;
using DataAccess.Models;

namespace DataAccess.Managers
{
	public class UserManager : BaseManager<User>, IUserManager
	{
		public UserManager(MainContext dbContext) : base(dbContext) { }
		public Task<User> LoginAsync(string token)
		{
			throw new NotImplementedException();
		}
	}
}
