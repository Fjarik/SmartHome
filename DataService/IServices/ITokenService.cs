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
		bool IsValid(string token);

		int GetUserId(string token);
		Token RegisterToken(Token t);

		Token RegisterToken(string token, int userId, DateTime expiration);

		bool Delete(string token);
		bool DeleteByUserId(int userId);
	}
}