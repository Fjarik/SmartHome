using System;
using System.Collections.Generic;
using System.Linq;
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
	public class CategoryService : BaseService<Category, ICategoryRepository>, ICategoryService
	{
		public CategoryService(ICategoryRepository repository) : base(repository) { }

		public bool Exists(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return false;
			}
			return this.Repository.Exists(name);
		}

		public List<Category> GetByIds(IList<int> ids)
		{
			if (!ids.Any()) {
				return new List<Category>();
			}
			return this.Repository.GetByIds(ids);
		}

		public HomeResult<Category> Create(string name, string description, bool isHealthy = false)
		{
			if (string.IsNullOrEmpty(name) ||
				string.IsNullOrEmpty(description)) {
				return new HomeResult<Category>(StatusCode.InvalidInput);
			}

			if (this.Exists(name)) {
				return new HomeResult<Category>(StatusCode.AlreadyExists);
			}

			var u = this.Repository.Create(name, description, isHealthy);
			if (u?.Entity == null) {
				return new HomeResult<Category>(StatusCode.InternalError);
			}

			return new HomeResult<Category>(StatusCode.OK, u.Entity);
		}
	}
}