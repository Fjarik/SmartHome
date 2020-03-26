using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using DataAccess.Repositories;

namespace DataService.IServices
{
	public interface ITokenService : IBaseService<Token, ITokenRepository>
	{
		Claim[] GetClaims(User u);
		ClaimsIdentity GetClaimsIdentity(User u);
		Token GetToken(User u);
		bool ValidateToken(string token);
		Task<bool> IsValidAsync(string token, CancellationToken cancellationToken);

		Task<int> GetUserIdAsync(string token, CancellationToken cancellationToken);
		Task<Token> RegisterTokenAsync(Token t, CancellationToken cancellationToken);

		Task<Token> RegisterTokenAsync(string token, int userId, DateTime expiration,
									   CancellationToken cancellationToken);
	}
}