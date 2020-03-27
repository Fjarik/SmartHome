using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using DataAccess.Repositories;
using DataService.IServices;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DataService.Services
{
	public class TokenService : BaseService<Token, ITokenRepository>, ITokenService
	{
		private readonly AppSettings _appSettings;

		public TokenService(ITokenRepository repository,
							IOptions<AppSettings> appSettings) : base(repository)
		{
			_appSettings = appSettings.Value;
		}

		public Claim[] GetClaims(User u)
		{
			return new[] {
				new Claim(JwtRegisteredClaimNames.FamilyName, u.Lastname),
				new Claim(JwtRegisteredClaimNames.GivenName, u.Firstname),
				new Claim(JwtRegisteredClaimNames.Email, u.Email),
				new Claim("publicId", u.Id.ToString()),
			};
		}

		public ClaimsIdentity GetClaimsIdentity(User u)
		{
			return new ClaimsIdentity(GetClaims(u));
		}

		public Token GetToken(User u)
		{
			var handler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var expiration = DateTime.Now.AddHours(_appSettings.ExpirationHours);
			var cred = new SigningCredentials(new SymmetricSecurityKey(key),
											  SecurityAlgorithms.HmacSha256Signature);

			var desc = new SecurityTokenDescriptor {
				Subject = this.GetClaimsIdentity(u),
				Expires = expiration,
				SigningCredentials = cred,
				Issuer = _appSettings.Issuer,
				Audience = _appSettings.Audience
			};

			var t = handler.CreateToken(desc);
			if (!handler.CanWriteToken) {
				return null;
			}

			var tokenString = handler.WriteToken(t);

			return new Token {
				Expiration = expiration,
				UserId = u.Id,
				TokenString = tokenString,
			};
		}

		public bool ValidateToken(string token)
		{
			var handler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var cred = new SymmetricSecurityKey(key);

			try {
				handler.ValidateToken(token, new TokenValidationParameters {
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = _appSettings.Issuer,
					ValidAudience = _appSettings.Audience,
					IssuerSigningKey = cred,
				}, out SecurityToken validatedToken);
			} catch {
				return false;
			}
			return true;
		}

		public bool IsValid(string token)
		{
			if (string.IsNullOrWhiteSpace(token)) {
				return false;
			}
			var t = this.Repository.GetByToken(token);
			if (t == null) {
				return false;
			}
			return t.IsValid;
		}

		public int GetUserId(string token)
		{
			return this.Repository.GetUserId(token);
		}

		public Token RegisterToken(Token t)
		{
			if (t == null || string.IsNullOrWhiteSpace(t.TokenString) || t.UserId < 1 || t.Expiration < DateTime.Now) {
				return null;
			}
			return RegisterToken(t.TokenString, t.UserId, t.Expiration);
		}

		public Token RegisterToken(string token, int userId, DateTime expiration)
		{
			var t = this.Repository.Create(token, userId, expiration);
			return t?.Entity;
		}
	}
}