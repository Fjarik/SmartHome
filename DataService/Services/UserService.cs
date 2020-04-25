using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

		public HomeResult<User> GetByGoogleId(string googleId)
		{
			if (string.IsNullOrWhiteSpace(googleId)) {
				return new HomeResult<User>(StatusCode.InvalidId);
			}
			googleId = this.NormalizeGoogleId(googleId);
			var u = this.Repository.GetByGoogleId(googleId);
			if (u == null) {
				return new HomeResult<User>(StatusCode.NotFound);
			}
			return new HomeResult<User>(StatusCode.OK, u);
		}

		public bool Exists(string googleId)
		{
			if (string.IsNullOrWhiteSpace(googleId)) {
				return false;
			}
			googleId = this.NormalizeGoogleId(googleId);
			return this.Repository.Exists(googleId);
		}

		public HomeResult<User> Register(string googleId,
										 string email,
										 string firstname,
										 string lastname)
		{
			if (string.IsNullOrWhiteSpace(email) ||
				string.IsNullOrWhiteSpace(firstname) ||
				string.IsNullOrWhiteSpace(lastname)) {
				return new HomeResult<User>(StatusCode.InvalidInput);
			}
			if (string.IsNullOrWhiteSpace(googleId)) {
				return new HomeResult<User>(StatusCode.InvalidId);
			}
			googleId = this.NormalizeGoogleId(googleId);

			if (this.Exists(googleId)) {
				return new HomeResult<User>(StatusCode.AlreadyExists);
			}

			var u = this.Repository.Create(email, firstname, lastname, googleId);
			if (u?.Entity == null) {
				return new HomeResult<User>(StatusCode.InternalError);
			}
			return new HomeResult<User>(StatusCode.OK, u.Entity);
		}

		public int SaveUser(User u)
		{
			if (u == null) {
				return 0;
			}
			return this.Repository.Save(u);
		}

		public string NormalizeGoogleId(string googleId) => googleId.Trim().ToLower();
	}
}