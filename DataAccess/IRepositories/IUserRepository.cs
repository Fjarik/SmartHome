using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.IRepositories
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task<User> LoginAsync(string token);
	}
}