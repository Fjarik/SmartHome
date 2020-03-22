using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.IRepositories;
using DataAccess.Models;

namespace DataAccess.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(MainContext dbContext) : base(dbContext) { }

		public Task<User> LoginAsync(string token)
		{
			throw new NotImplementedException();
		}
	}
}