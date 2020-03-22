using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using SharedLibrary.Objects;

namespace DataService.IServices
{
	public interface IUserService : IBaseService<User, IUserRepository>
	{
		Task<HomeResult<User>> GetByGoogleIdAsync(string googleId);
		Task<bool> ExistsAsync(string googleId);
		Task<HomeResult<User>> RegisterAsync(string googleId, string email, string firstname, string lastname);

		Task<bool> SaveUserAsync(User u);
	}
}