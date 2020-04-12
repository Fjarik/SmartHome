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
			return this.Create(input.Date, input.Type, input.Time,
							   input.FoodId, input.SoupId,
							   input.SideDishId, input.OriginalMealId);
		}

		public HomeResult<Meal> Create(DateTime date, MealTypes type, MealTimes time = MealTimes.Lunch,
									   int? foodId = null, int? soupId = null,
									   int? sideId = null, int? originalMealId = null)
		{
			return this.Create(date, (short) type, (short) time, foodId, soupId, sideId, originalMealId);
		}

		public HomeResult<Meal> Create(DateTime date, short typeId, short timeId,
									   int? foodId = null, int? soupId = null,
									   int? sideId = null, int? originalMealId = null)
		{
			if (typeId < 1) {
				return new HomeResult<Meal>(StatusCode.NotValidId);
			}

			if ((foodId != null && foodId < 1) ||
				(soupId != null && soupId < 1) ||
				(originalMealId != null && originalMealId < 1) ||
				(sideId != null && sideId < 1)) {
				return new HomeResult<Meal>(StatusCode.NotValidId);
			}

			var m = this.Repository.Create(date, typeId, timeId, foodId, soupId, sideId, originalMealId);
			if (m?.Entity == null) {
				return new HomeResult<Meal>(StatusCode.InternalError);
			}

			return new HomeResult<Meal>(StatusCode.OK, m.Entity);
		}
	}
}