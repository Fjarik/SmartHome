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

		public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return false;
			}
			return await this.Repository.ExistsAsync(name, cancellationToken);
		}

		public async Task<List<Category>> GetByIdsAsync(IList<int> ids, CancellationToken cancellationToken)
		{
			if (!ids.Any()) {
				return new List<Category>();
			}
			return await this.Repository.GetByIdsAsync(ids, cancellationToken);
		}

		public async Task<HomeResult<Category>> CreateAsync(string name, string description,
															CancellationToken cancellationToken, bool isHealthy = false)
		{
			if (string.IsNullOrEmpty(name) ||
				string.IsNullOrEmpty(description)) {
				return new HomeResult<Category>(StatusCode.InvalidInput);
			}

			if (await this.ExistsAsync(name, cancellationToken)) {
				return new HomeResult<Category>(StatusCode.AlreadyExists);
			}

			var u = await this.Repository.CreateAsync(name, description, cancellationToken, isHealthy);
			if (u?.Entity == null) {
				return new HomeResult<Category>(StatusCode.InternalError);
			}

			return new HomeResult<Category>(StatusCode.OK, u.Entity);
		}
	}
}