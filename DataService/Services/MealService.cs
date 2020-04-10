using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.IRepositories;
using DataAccess.Models;
using DataService.IServices;
using SharedLibrary.Enums;
using SharedLibrary.Objects;

namespace DataService.Services
{
	public class MealService : BaseService<Meal, IMealRepository>, IMealService
	{
		public MealService(IMealRepository repository) : base(repository) { }

		public List<Meal> GetByDate(DateTime date)
		{
			return this.Repository.GetByDate(date);
		}

		public HomeResult<Meal> Create(MealInput input)
		{
			if (input == null) {
				return new HomeResult<Meal>(StatusCode.InvalidInput);
			}
			if (!input.IsValid) {
				return new HomeResult<Meal>(StatusCode.NotValidId);
			}
			return this.Create(input.FoodId, input.Type, input.Date, input.OriginalMealId);
		}

		public HomeResult<Meal> Create(int foodId, MealTypes type, DateTime date, int? originalMealId = null)
		{
			return this.Create(foodId, (int) type, date, originalMealId);
		}

		public HomeResult<Meal> Create(int foodId, int typeId, DateTime date, int? originalMealId = null)
		{
			if (foodId < 1 ||
				typeId < 1) {
				return new HomeResult<Meal>(StatusCode.NotValidId);
			}

			if (originalMealId != null && originalMealId < 1) {
				return new HomeResult<Meal>(StatusCode.NotValidId);
			}

			var m = this.Repository.Create(foodId, typeId, date, originalMealId);
			if (m?.Entity == null) {
				return new HomeResult<Meal>(StatusCode.InternalError);
			}

			return new HomeResult<Meal>(StatusCode.OK, m.Entity);
		}
	}
}