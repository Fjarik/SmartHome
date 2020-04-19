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

#region Create

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

#endregion

#region Update

		public HomeResult<Food> Update(int foodId, FoodInput input)
		{
			if (input == null || !input.IsValid) {
				return new HomeResult<Food>(StatusCode.InvalidInput, nameof(input));
			}
			return Update(foodId,
						  input.Name, input.Type,
						  input.CategoryIds, input.SideIds,
						  input.GlutenFree);
		}

		public HomeResult<Food> Update(int foodId,
									   string name, FoodTypes type,
									   List<int> categoryIds, List<int> sideIds,
									   bool glutenFree)
		{
			return Update(foodId,
						  name, (int) type,
						  categoryIds, sideIds,
						  glutenFree);
		}

		public HomeResult<Food> Update(int foodId,
									   string name, int typeId,
									   List<int> categoryIds, List<int> sideIds,
									   bool glutenFree)
		{
			if (foodId < 1) {
				return new HomeResult<Food>(StatusCode.NotValidId);
			}
			var res = this.GetById(foodId);
			if (!res.IsSuccess) {
				return res;
			}
			var f = res.Content;
			return Update(f,
						  name, typeId,
						  categoryIds, sideIds,
						  glutenFree);
		}

		public HomeResult<Food> Update(Food original,
									   string name, int typeId,
									   List<int> categoryIds, List<int> sideIds,
									   bool glutenFree)
		{
			if (original == null) {
				return new HomeResult<Food>(StatusCode.NotFound);
			}

			var changed = false;

			if (original.Name != name) {
				original.Name = name;
				changed = true;
			}
			if (original.TypeId != typeId) {
				original.TypeId = typeId;
				changed = true;
			}
			if (original.GlutenFree != glutenFree) {
				original.GlutenFree = glutenFree;
				changed = true;
			}

			if (changed) {
				this.Repository.Save(original);
			}

			var foodId = original.Id;

			// Categories
			var toRemove = original.CategoryIds.Except(categoryIds).ToList();
			var toAdd = categoryIds.Except(original.CategoryIds).ToList();
			if (toRemove.Count > 0) {
				this.Repository.RemoveFoodCategories(foodId, toRemove);
			}
			if (toAdd.Count > 0) {
				this.Repository.CreateFoodCategories(foodId, toAdd);
			}

			// Side dishes
			toRemove = original.SideIds.Except(sideIds).ToList();
			toAdd = sideIds.Except(original.SideIds).ToList();
			if (toRemove.Count > 0) {
				this.Repository.RemoveFoodSides(foodId, toRemove);
			}
			if (toAdd.Count > 0) {
				this.Repository.CreateFoodSides(foodId, toAdd);
			}

			return this.GetById(foodId);
		}

#endregion
	}
}