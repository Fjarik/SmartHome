using System;
using System.Collections.Generic;
using System.Text;
using SharedLibrary.Interfaces;

namespace SharedLibrary.Objects
{
	public class AuthToken : IAuthToken
	{
		public string AccessToken { get; set; }
		public DateTime Expiration { get; set; }
		public string RefreshToken { get; set; }

		public AuthToken() { }

		public AuthToken(IAuthToken token)
		{
			this.Expiration = token.Expiration;
			this.AccessToken = token.AccessToken;
			this.RefreshToken = token.RefreshToken;
		}
	}
}