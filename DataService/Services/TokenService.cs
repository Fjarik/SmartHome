using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using DataAccess.Repositories;
using DataService.IServices;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Enums;
using SharedLibrary.Objects;

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

#region Generate

#region Claims

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

		public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
		{
			throw new NotImplementedException();
		}

#endregion

#region Tokens

		public byte[] GenerateRefreshToken()
		{
			var ran = new byte[32];
			using (var rnd = RandomNumberGenerator.Create()) {
				rnd.GetBytes(ran);
			}
			return ran;
		}

		public Token GetToken(User u)
		{
			var handler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var expiration = DateTime.UtcNow.AddHours(_appSettings.ExpirationHours);
			var cred = new SigningCredentials(new SymmetricSecurityKey(key),
											  SecurityAlgorithms.HmacSha256Signature);

			var desc = new SecurityTokenDescriptor {
				Subject = this.GetClaimsIdentity(u),
				NotBefore = DateTime.UtcNow,
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

			var refreshBytes = this.GenerateRefreshToken();

			return new Token {
				Expiration = expiration,
				UserId = u.Id,
				AccessToken = tokenString,
				RefreshTokenBytes = refreshBytes,
			};
		}

#endregion

#endregion

		public Token GetByToken(string token)
		{
			if (string.IsNullOrWhiteSpace(token)) {
				return null;
			}

			return this.Repository.GetByToken(token);
		}

#region Validation

		public HomeResult<bool> ValidateToken(string token, bool validateExpiration = true)
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
					ValidateLifetime = validateExpiration,
				}, out SecurityToken validatedToken);
				if (!(validatedToken is JwtSecurityToken t)) {
					return new HomeResult<bool>(StatusCode.InvalidInput);
				}
				if (!t.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase)) {
					return new HomeResult<bool>(StatusCode.InvalidInput);
				}
			} catch (SecurityTokenExpiredException) {
				return new HomeResult<bool>(StatusCode.Expired);
			} catch (Exception ex) {
				return new HomeResult<bool>(StatusCode.SeeException, ex);
			}
			return new HomeResult<bool>(StatusCode.OK, true);
		}

		public HomeResult<bool> IsValid(string token)
		{
			if (string.IsNullOrWhiteSpace(token)) {
				return new HomeResult<bool>(StatusCode.InvalidInput);
			}
			var t = this.GetByToken(token);
			if (t == null) {
				return new HomeResult<bool>(StatusCode.NotFound);
			}
			return new HomeResult<bool>(StatusCode.OK, t.IsValid);
		}

#endregion

		public int GetUserId(string token)
		{
			return this.Repository.GetUserId(token);
		}

#region Create

		public Token RegisterToken(Token t)
		{
			if (t == null) {
				return null;
			}
			return RegisterToken(t.AccessToken, t.UserId, t.Expiration, t.RefreshTokenBytes);
		}

		public Token RegisterToken(string token, int userId, DateTime expiration, byte[] refreshToken)
		{
			if (string.IsNullOrWhiteSpace(token) || userId < 1 || expiration < DateTime.Now) {
				return null;
			}

			var t = this.Repository.Create(token, userId, expiration, refreshToken);
			return t?.Entity;
		}

#endregion

#region Delete

		public bool Delete(string token)
		{
			if (string.IsNullOrWhiteSpace(token)) {
				return false;
			}
			return this.Repository.Delete(token);
		}

		public bool DeleteByUserId(int userId)
		{
			if (userId < 1) {
				return false;
			}
			return this.Repository.DeleteByUserId(userId);
		}

#endregion
	}
}