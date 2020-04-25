using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using DataAccess.Repositories;
using SharedLibrary.Objects;

namespace DataService.IServices
{
	public interface ITokenService : IBaseService<Token, ITokenRepository>
	{
		Claim[] GetClaims(User u);
		ClaimsIdentity GetClaimsIdentity(User u);

		ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
		byte[] GenerateRefreshToken();
		Token GetToken(User u);

		Token GetByToken(string token);

		HomeResult<bool> ValidateToken(string token, bool validateExpiration = true);
		HomeResult<bool> IsValid(string token);

		int GetUserId(string token);
		Token RegisterToken(Token t);

		Token RegisterToken(string token, int userId, DateTime expiration, byte[] refreshToken);

		bool Delete(string token);
		bool DeleteByUserId(int userId);
	}
}