using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.IRepositories
{
	public interface IUserRepository : IBaseRepository<User>
	{
		bool Exists(string googleId);
		User GetByGoogleId(string googleId);
		EntityEntry<User> Create(string email, string firstname, string lastname, string googleId);
	}
}