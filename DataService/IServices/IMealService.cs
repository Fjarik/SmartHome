﻿using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.IRepositories;
using DataAccess.Models;
using SharedLibrary.Enums;
using SharedLibrary.Objects;

namespace DataService.IServices
{
	public interface IMealService : IBaseService<Meal, IMealRepository>
	{
		List<Meal> GetByDate(DateTime date);
		List<Meal> GetByDate(DateTime date, int daysBefore, int daysAfter);

#region Create

		HomeResult<Meal> Create(MealInput input);

		HomeResult<Meal> Create(DateTime date, MealTypes type, MealTimes time,
								int? foodId = null, int? soupId = null,
								int? sideId = null, int? originalMealId = null);

		HomeResult<Meal> Create(DateTime date, short typeId, short timeId,
								int? foodId = null, int? soupId = null,
								int? sideId = null, int? originalMealId = null);

#endregion

#region Remove

		// Including related meals
		bool Remove(int mealId, bool incRelated);
		bool Remove(Meal entity, bool incRelated);

#endregion
	}
}