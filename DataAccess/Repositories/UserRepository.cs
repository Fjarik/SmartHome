using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

		public async Task<bool> ExistsAsync(string googleId, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(googleId)) {
				return false;
			}
			return await this.DbSet.AnyAsync(x => x.GoogleId == googleId, cancellationToken);
		}

		public Task<User> GetByGoogleIdAsync(string googleId, CancellationToken cancellationToken)
		{
			return this.DbSet.FirstOrDefaultAsync(x => x.GoogleId == googleId, cancellationToken);
		}

		public async ValueTask<EntityEntry<User>> CreateAsync(string email, string firstname, string lastname,
															  string googleId, CancellationToken cancellationToken)
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

			return await CreateAsync(u, cancellationToken);
		}
	}
}