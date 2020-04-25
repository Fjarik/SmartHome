using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.IRepositories
{
	public interface ITokenRepository : IBaseRepository<Token>
	{
		int GetUserId(string token);
		Token GetByToken(string token);
		EntityEntry<Token> Create(string token, int userId, DateTime expiration, byte[] refreshToken);
		bool Delete(string token);
		bool DeleteByUserId(int userId);
	}
}