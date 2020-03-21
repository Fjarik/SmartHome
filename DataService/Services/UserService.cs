using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.IManagers;
using DataAccess.Managers;
using DataAccess.Models;
using DataService.IServices;

namespace DataService.Services
{
	public class UserService : BaseService<User, IUserManager>, IUserService
	{
		public UserService(IUserManager mgr) : base(mgr) { }

	}
}