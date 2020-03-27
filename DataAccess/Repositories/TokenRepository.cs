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
	public class TokenRepository : BaseRepository<Token>, ITokenRepository
	{
		public TokenRepository(MainContext dbContext) : base(dbContext) { }

		public int GetUserId(string token)
		{
			return this.DbSet
					   .Where(x => x.TokenString == token)
					   .Select(x => x.UserId)
					   .FirstOrDefault();
		}

		public Token GetByToken(string token)
		{
			return this.DbSet.FirstOrDefault(x => x.TokenString == token);
		}

		public EntityEntry<Token> Create(string token, int userId, DateTime expiration)
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

			return this.Create(t);
		}
	}
}