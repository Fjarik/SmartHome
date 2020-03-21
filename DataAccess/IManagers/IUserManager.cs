using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.IManagers
{
	public interface IUserManager : IBaseManager<User>
	{
		Task<User> LoginAsync(string token);
	}
}