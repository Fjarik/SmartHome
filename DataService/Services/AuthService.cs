using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Models;
using DataService.IServices;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;

namespace DataService.Services
{
	public class AuthService : IAuthService
	{
		private readonly IUserService _userService;

		public AuthService(IUserService userService)
		{
			_userService = userService;
		}

		public Userinfoplus GetGoogleUser(string googleToken)
		{
			var service = new Oauth2Service(new BaseClientService.Initializer {
				HttpClientInitializer = GoogleCredential.FromAccessToken(googleToken),
				ApplicationName = "Domov",
			});
			return service.Userinfo.Get().Execute();
		}
	}
}