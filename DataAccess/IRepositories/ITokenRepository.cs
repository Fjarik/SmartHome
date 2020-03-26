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
		Task<int> GetUserIdAsync(string token, CancellationToken cancellationToken);
		Task<Token> GetByTokenAsync(string token, CancellationToken cancellationToken);

		ValueTask<EntityEntry<Token>> CreateAsync(string token, int userId, DateTime expiration,
												  CancellationToken cancellationToken);
	}
}