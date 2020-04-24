using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.IRepositories
{
	public interface IMealRepository : IBaseRepository<Meal>
	{
		List<Meal> GetByDate(DateTime date);
		List<Meal> GetByDate(DateTime minDate, DateTime maxDate);

		List<int> GetRealtedMealIds(int originalMealId);
		List<Meal> GetRealtedMeals(int originalMealId);

		EntityEntry<Meal> Create(DateTime date, short typeId, short timeId,
								 int? foodId = null, int? soupId = null,
								 int? sideId = null, int? originalMealId = null);

		bool RemoveRelatedMeals(int originalMealId);
	}
}