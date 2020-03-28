using System;
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
		HomeResult<Meal> Create(int cookedById, int foodId, MealTypes type, DateTime date);
		HomeResult<Meal> Create(int cookedById, int foodId, int typeId, DateTime date);
	}
}