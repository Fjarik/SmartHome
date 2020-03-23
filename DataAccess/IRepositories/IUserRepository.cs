using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.IRepositories
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task<bool> ExistsAsync(string googleId);
		Task<User> GetByGoogleIdAsync(string googleId);
		ValueTask<EntityEntry<User>> CreateAsync(string email, string firstname, string lastname, string googleId);
	}
}