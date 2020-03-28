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
			return this.Create(input.CookedById, input.FoodId, input.Type, input.Date);
		}

		public HomeResult<Meal> Create(int cookedById, int foodId, MealTypes type, DateTime date)
		{
			return this.Create(cookedById, foodId, (int) type, date);
		}

		public HomeResult<Meal> Create(int cookedById, int foodId, int typeId, DateTime date)
		{
			if (cookedById < 1 ||
				foodId < 1 ||
				typeId < 1) {
				return new HomeResult<Meal>(StatusCode.NotValidId);
			}
			var m = this.Repository.Create(cookedById, foodId, typeId, date);
			if (m?.Entity == null) {
				return new HomeResult<Meal>(StatusCode.InternalError);
			}

			return new HomeResult<Meal>(StatusCode.OK, m.Entity);
		}
	}
}