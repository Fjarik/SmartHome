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
		EntityEntry<Meal> Create(int foodId, int typeId, DateTime date, int? sideId = null, int? originalMealId = null);
	}
}