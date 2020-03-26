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
		Task<HomeResult<User>> GetByGoogleIdAsync(string googleId, CancellationToken cancellationToken);
		Task<bool> ExistsAsync(string googleId, CancellationToken cancellationToken);

		Task<HomeResult<User>> RegisterAsync(string googleId, string email, string firstname, string lastname,
											 CancellationToken cancellationToken);

		Task<int> SaveUserAsync(User u, CancellationToken cancellationToken);
		string NormalizeGoogleId(string googleId);
	}
}