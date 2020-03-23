using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using DataService.IServices;
using SharedLibrary.Enums;
using SharedLibrary.Objects;

namespace DataService.Services
{
	public class UserService : BaseService<User, IUserRepository>, IUserService
	{
		public UserService(IUserRepository repository) : base(repository) { }

		public async Task<HomeResult<User>> GetByGoogleIdAsync(string googleId)
		{
			if (string.IsNullOrWhiteSpace(googleId)) {
				return new HomeResult<User>(StatusCode.NotValidId);
			}
			googleId = this.NormalizeGoogleId(googleId);
			var u = await this.Repository.GetByGoogleIdAsync(googleId);
			if (u == null) {
				return new HomeResult<User>(StatusCode.NotFound);
			}
			return new HomeResult<User>(StatusCode.OK, u);
		}

		public async Task<bool> ExistsAsync(string googleId)
		{
			if (string.IsNullOrWhiteSpace(googleId)) {
				return false;
			}
			googleId = this.NormalizeGoogleId(googleId);
			return await this.Repository.ExistsAsync(googleId);
		}

		public async Task<HomeResult<User>> RegisterAsync(string googleId,
														  string email,
														  string firstname,
														  string lastname)
		{
			if (string.IsNullOrEmpty(email) ||
				string.IsNullOrEmpty(firstname) ||
				string.IsNullOrEmpty(lastname)) {
				return new HomeResult<User>(StatusCode.InvalidInput);
			}
			if (string.IsNullOrWhiteSpace(googleId)) {
				return new HomeResult<User>(StatusCode.NotValidId);
			}
			googleId = this.NormalizeGoogleId(googleId);

			if (await this.ExistsAsync(googleId)) {
				return new HomeResult<User>(StatusCode.AlreadyExists);
			}

			var u = await this.Repository.CreateAsync(email, firstname, lastname, googleId);
			if (u?.Entity == null) {
				return new HomeResult<User>(StatusCode.InternalError);
			}
			return new HomeResult<User>(StatusCode.OK, u.Entity);
		}

		public async Task<int> SaveUserAsync(User u)
		{
			if (u == null) {
				return 0;
			}
			return await this.Repository.SaveAsync(u);
		}

		public string NormalizeGoogleId(string googleId) => googleId.Trim().ToLower();
	}
}