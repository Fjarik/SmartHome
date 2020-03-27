using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using SharedLibrary.Objects;

namespace DataService.IServices
{
	public interface IUserService : IBaseService<User, IUserRepository>
	{
		HomeResult<User> GetByGoogleId(string googleId);
		bool Exists(string googleId);

		HomeResult<User> Register(string googleId, string email, string firstname, string lastname);

		int SaveUser(User u);
		string NormalizeGoogleId(string googleId);
	}
}