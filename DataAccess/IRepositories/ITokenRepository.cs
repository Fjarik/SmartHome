using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.IRepositories
{
	public interface ITokenRepository : IBaseRepository<Token>
	{
		Task<int> GetUserIdAsync(string token);
		Task<Token> GetByTokenAsync(string token);
		ValueTask<EntityEntry<Token>> CreateAsync(string token, int userId, DateTime expiration);
	}
}