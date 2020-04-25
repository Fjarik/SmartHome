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
					   .Where(x => x.AccessToken == token)
					   .Select(x => x.UserId)
					   .FirstOrDefault();
		}

		public Token GetByToken(string token)
		{
			return this.DbSet.FirstOrDefault(x => x.AccessToken == token);
		}

		public EntityEntry<Token> Create(string token, int userId, DateTime expiration, byte[] refreshToken)
		{
			if (string.IsNullOrWhiteSpace(token) ||
				userId < 1 ||
				expiration < DateTime.Now) {
				return null;
			}

			var t = new Token {
				UserId = userId,
				AccessToken = token,
				Expiration = expiration,
				Created = DateTime.Now,
				RefreshTokenBytes = refreshToken,
			};

			return this.Create(t);
		}

		public bool Delete(string token)
		{
			var t = this.GetByToken(token);
			if (t == null) {
				return false;
			}
			this.DbSet.Remove(t);
			this.Save();
			return true;
		}

		public bool DeleteByUserId(int userId)
		{
			var tokens = this.DbSet.Where(x => x.UserId == userId);
			this.DbSet.RemoveRange(tokens);
			this.Save();
			return true;
		}
	}
}