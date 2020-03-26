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
	public class FoodService : BaseService<Food, IFoodRepository>, IFoodService
	{
		private readonly ICategoryService _categoryService;

		public FoodService(IFoodRepository repository, ICategoryService categoryService) : base(repository)
		{
			_categoryService = categoryService;
		}

		public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return false;
			}
			return await this.Repository.ExistsAsync(name, cancellationToken);
		}

		public async Task<List<Category>> GetCategoriesAsync(int foodId, CancellationToken cancellationToken)
		{
			var ids = await this.Repository.GetCategoryIdsAsync(foodId, cancellationToken);
			if (!ids.Any()) {
				return new List<Category>();
			}
			return await this._categoryService.GetByIdsAsync(ids, cancellationToken);
		}

		public async Task<HomeResult<Food>> CreateAsync(string name, int typeId, IList<int> categories,
														CancellationToken cancellationToken,
														bool glutenFree = true)
		{
			if (string.IsNullOrEmpty(name) ||
				!categories.Any() ||
				categories.Any(x => x < 1) ||
				typeId < 1) {
				return new HomeResult<Food>(StatusCode.InvalidInput);
			}


			if (await this.ExistsAsync(name, cancellationToken)) {
				return new HomeResult<Food>(StatusCode.AlreadyExists);
			}

			var u = await this.Repository.CreateAsync(name, typeId, cancellationToken, glutenFree);
			if (u?.Entity == null) {
				return new HomeResult<Food>(StatusCode.InternalError);
			}

			// TODO: Create food categories

			return new HomeResult<Food>(StatusCode.OK, u.Entity);
		}
	}
}