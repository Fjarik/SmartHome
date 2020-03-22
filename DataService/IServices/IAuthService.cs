using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Google.Apis.Oauth2.v2.Data;

namespace DataService.IServices
{
	public interface IAuthService
	{
		Task<Userinfoplus> GetGoogleUserAsync(string googleToken);
		Task<User> LoginOrRegisterAsync(string googleId, string email);
	}
}