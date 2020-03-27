using System;
using System.Collections.Generic;
using System.Linq;
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

		public bool Exists(string googleId)
		{
			if (string.IsNullOrWhiteSpace(googleId)) {
				return false;
			}
			return this.DbSet.Any(x => x.GoogleId == googleId);
		}

		public User GetByGoogleId(string googleId)
		{
			return this.DbSet.FirstOrDefault(x => x.GoogleId == googleId);
		}

		public EntityEntry<User> Create(string email, string firstname, string lastname,
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

			return Create(u);
		}
	}
}