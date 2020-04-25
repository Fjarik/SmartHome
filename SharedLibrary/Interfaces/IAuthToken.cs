using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Interfaces
{
	public interface IAuthToken
	{
		string AccessToken { get; set; }
		DateTime Expiration { get; set; }
		string RefreshToken { get; }
	}
}