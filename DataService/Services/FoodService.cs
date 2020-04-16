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

		public List<Food> GetByTypes(params FoodTypes[] types)
		{
			var ids = types.Select(x => (int) x)
						   .Distinct()
						   .ToArray();

			return this.GetByTypes(ids);
		}

		public List<Food> GetByTypes(params int[] ids)
		{
			var types = ids.Distinct().ToArray();
			if (!types.Any()) {
				return new List<Food>();
			}
			return this.Repository.GetByTypes(types);
		}

		public HomeResult<Food> Create(FoodInput input)
		{
			if (input == null || !input.IsValid) {
				return new HomeResult<Food>(StatusCode.InvalidInput, nameof(input));
			}
			return this.Create(input.Name, input.Type, input.CategoryIds, input.SideIds, input.GlutenFree);
		}

		public HomeResult<Food> Create(string name, FoodTypes type,
									   List<int> categoryIds,
									   List<int> sideIds,
									   bool glutenFree = true)
		{
			return this.Create(name, (int) type, categoryIds, sideIds, glutenFree);
		}

		public HomeResult<Food> Create(string name,
									   int typeId,
									   List<int> categoryIds,
									   List<int> sideIds,
									   bool glutenFree = true)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return new HomeResult<Food>(StatusCode.InvalidInput);
			}

			if (typeId < 1) {
				return new HomeResult<Food>(StatusCode.NotValidId, nameof(typeId));
			}

			if (categoryIds.Any(x => x < 1)) {
				return new HomeResult<Food>(StatusCode.NotValidId, nameof(categoryIds));
			}

			if (sideIds.Any(x => x < 1)) {
				return new HomeResult<Food>(StatusCode.NotValidId, nameof(sideIds));
			}

			if (this.Exists(name)) {
				return new HomeResult<Food>(StatusCode.AlreadyExists);
			}

			var f = this.Repository.Create(name, typeId, glutenFree);
			var food = f?.Entity;
			if (food == null) {
				return new HomeResult<Food>(StatusCode.InternalError);
			}
			var catgs = this.Repository.CreateFoodCategories(food.Id, categoryIds);
			var sides = this.Repository.CreateFoodSides(food.Id, sideIds);

			food.FoodCategories = catgs;
			food.FoodSideFoods = sides;
			return new HomeResult<Food>(StatusCode.OK, food);
		}
	}
}