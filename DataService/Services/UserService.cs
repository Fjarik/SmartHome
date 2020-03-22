using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using DataService.IServices;
using SharedLibrary.Objects;

namespace DataService.Services
{
	public class UserService : BaseService<User, IUserRepository>, IUserService
	{
		public UserService(IUserRepository mgr) : base(mgr) { }

		public Task<HomeResult<User>> GetByGoogleIdAsync(string googleId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> ExistsAsync(string googleId)
		{
			throw new NotImplementedException();
		}
	}
}