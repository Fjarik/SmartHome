using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repositories
{
	public class TokenRepository : BaseRepository<Token>, ITokenRepository
	{
		public TokenRepository(MainContext dbContext) : base(dbContext) { }

		public Task<int> GetUserIdAsync(string token)
		{
			return this.DbSet.Where(x => x.TokenString == token).Select(x => x.UserId).FirstOrDefaultAsync();
		}

		public Task<Token> GetByTokenAsync(string token)
		{
			return this.DbSet.FirstOrDefaultAsync(x => x.TokenString == token);
		}

		public async ValueTask<EntityEntry<Token>> CreateAsync(string token, int userId, DateTime expiration)
		{
			if (string.IsNullOrWhiteSpace(token) ||
				userId < 1 ||
				expiration < DateTime.Now) {
				return null;
			}

			var t = new Token {
				UserId = userId,
				TokenString = token,
				Expiration = expiration,
				Created = DateTime.Now,
			};

			return await this.CreateAsync(t);
		}
	}
}