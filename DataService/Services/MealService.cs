using System;
using System.Collections.Generic;
using System.Runtime;
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

#region Create

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

		public bool Remove(int mealId, bool incRelated)
		{
			if (mealId < 1) {
				return false;
			}
			if (incRelated) {
				var removeRes = this.Repository.RemoveRelatedMeals(mealId);
				if (!removeRes) {
					return false;
				}
			}

			var res = this.GetById(mealId);
			if (!res.IsSuccess) {
				return false;
			}
			return this.Remove(res.Content, incRelated);
		}

		public bool Remove(Meal entity, bool incRelated)
		{
			if (entity == null) {
				return false;
			}
			if (!incRelated && entity.IsRemoveable) {
				return false;
			}
			return this.Delete(entity);
		}

		public override bool Delete(int id)
		{
			throw new AmbiguousImplementationException("Use 'Remove' method instead");
		}

#endregion
	}
}