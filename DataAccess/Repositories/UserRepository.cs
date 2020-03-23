using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(MainContext dbContext) : base(dbContext) { }

		public async Task<bool> ExistsAsync(string googleId)
		{
			if (string.IsNullOrWhiteSpace(googleId)) {
				return false;
			}
			return await this.DbSet.AnyAsync(x => x.GoogleId == googleId);
		}

		public Task<User> GetByGoogleIdAsync(string googleId)
		{
			return this.DbSet.FirstOrDefaultAsync(x => x.GoogleId == googleId);
		}

		public async ValueTask<EntityEntry<User>> CreateAsync(string email, string firstname, string lastname,
															  string googleId)
		{
			if (string.IsNullOrEmpty(email) ||
				string.IsNullOrEmpty(firstname) ||
				string.IsNullOrEmpty(lastname) ||
				string.IsNullOrEmpty(googleId)) {
				return null;
			}
			var u = new User {
				Email = email,
				Firstname = firstname,
				Lastname = lastname,
				CreatedAt = DateTime.Now,
				GoogleId = googleId,
			};

			return await CreateAsync(u);
		}
	}
}