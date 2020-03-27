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

		public bool Exists(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return false;
			}
			return this.Repository.Exists(name);
		}

		public List<Category> GetCategories(int foodId)
		{
			var ids = this.Repository.GetCategoryIds(foodId);
			if (!ids.Any()) {
				return new List<Category>();
			}
			return this._categoryService.GetByIds(ids);
		}

		public HomeResult<Food> Create(string name, int typeId, IList<int> categories,
									   bool glutenFree = true)
		{
			if (string.IsNullOrEmpty(name) ||
				!categories.Any() ||
				categories.Any(x => x < 1) ||
				typeId < 1) {
				return new HomeResult<Food>(StatusCode.InvalidInput);
			}


			if (this.Exists(name)) {
				return new HomeResult<Food>(StatusCode.AlreadyExists);
			}

			var u = this.Repository.Create(name, typeId, glutenFree);
			if (u?.Entity == null) {
				return new HomeResult<Food>(StatusCode.InternalError);
			}

			// TODO: Create food categories

			return new HomeResult<Food>(StatusCode.OK, u.Entity);
		}
	}
}