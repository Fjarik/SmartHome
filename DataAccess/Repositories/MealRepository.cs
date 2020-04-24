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

		private IQueryable<Meal> _all => this.DbSet
											 .Include(x => x.MealCategories)
											 .Include(x => x.Food); // TODO: Edit

		public override List<Meal> GetAll()
		{
			return _all.ToList();
		}

		public List<Meal> GetByDate(DateTime date)
		{
			return this.GetByDate(date, date);
		}

		public List<Meal> GetByDate(DateTime minDate, DateTime maxDate)
		{
			return _all.Where(x => x.Date >= minDate &&
								   x.Date <= maxDate)
					   .ToList();
		}

		public List<int> GetRealtedMealIds(int originalMealId)
		{
			return this.DbSet
					   .Where(x => x.OriginalMealId == originalMealId)
					   .Select(x => x.Id)
					   .ToList();
		}

		public List<Meal> GetRealtedMeals(int originalMealId)
		{
			return this.DbSet
					   .Where(x => x.OriginalMealId == originalMealId)
					   .ToList();
		}

		public EntityEntry<Meal> Create(DateTime date, short typeId, short timeId,
										int? foodId = null, int? soupId = null,
										int? sideId = null, int? originalMealId = null)
		{
			var m = new Meal {
				FoodId = foodId,
				TypeId = typeId,
				TimeId = timeId,
				SoupId = soupId,
				OriginalMealId = originalMealId,
				SideId = sideId,
				Date = date.Date,
			};

			return this.Create(m);
		}

		public bool RemoveRelatedMeals(int originalMealId)
		{
			this.DbSet.Where(x => x.OriginalMealId == originalMealId)
				.DeleteFromQuery();

			return true;
		}
	}
}