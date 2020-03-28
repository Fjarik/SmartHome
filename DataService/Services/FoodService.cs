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

		public HomeResult<Food> Create(FoodInput input)
		{
			if (input == null || !input.IsValid) {
				return new HomeResult<Food>(StatusCode.InvalidInput);
			}
			return this.Create(input.Name, input.Type, input.Categories, input.GlutenFree);
		}

		public HomeResult<Food> Create(string name, FoodTypes type, IList<int> categories, bool glutenFree = true)
		{
			return this.Create(name, (int) type, categories, glutenFree);
		}

		public HomeResult<Food> Create(string name,
									   int typeId,
									   IList<int> categories,
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

			var f = this.Repository.Create(name, typeId, glutenFree);
			var food = f?.Entity;
			if (food == null) {
				return new HomeResult<Food>(StatusCode.InternalError);
			}
			var catgs = this.Repository.CreateFoodCategories(food.Id, categories);

			food.FoodCategories = catgs;
			return new HomeResult<Food>(StatusCode.OK, food);
		}
	}
}