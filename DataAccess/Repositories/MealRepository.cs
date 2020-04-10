using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Contexts;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repositories
{
	public class MealRepository : BaseRepository<Meal>, IMealRepository
	{
		public MealRepository(MainContext dbContext) : base(dbContext) { }

		public override List<Meal> GetAll()
		{
			return this.DbSet
					   .Include(x => x.MealCategories)
					   .Include(x => x.Food) // TODO: Edit
					   .ToList();
		}

		public List<Meal> GetByDate(DateTime date)
		{
			return this.DbSet.Where(x => x.Date.Date == date.Date).ToList();
		}

		public EntityEntry<Meal> Create(int foodId, int typeId, DateTime date, int? originalMealId = null)
		{
			if (foodId < 1 ||
				typeId < 1) {
				return null;
			}
			if (originalMealId != null && originalMealId < 1) {
				return null;
			}

			var m = new Meal {
				FoodId = foodId,
				TypeId = typeId,
				OriginalMealId = originalMealId,
				Date = date.Date,
			};

			return this.Create(m);
		}
	}
}