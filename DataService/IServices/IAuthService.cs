using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Models;
using Google.Apis.Oauth2.v2.Data;

namespace DataService.IServices
{
	public interface IAuthService
	{
		Userinfoplus GetGoogleUser(string googleToken);
	}
}