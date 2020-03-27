using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repositories
{
	public class FoodRepository : BaseRepository<Food>, IFoodRepository
	{
		public FoodRepository(MainContext dbContext) : base(dbContext) { }

		public override List<Food> GetAll()
		{
			return this.DbSet
					   .Include(x => x.Type) // TODO: Edit
					   .Include(x => x.FoodCategories)
					   .ToList();
		}

		public bool Exists(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return false;
			}
			return this.DbSet.Any(x => x.Name == name);
		}

		public List<int> GetCategoryIds(int foodId)
		{
			if (foodId < 1) {
				return new List<int>();
			}
			return this.DbContext
					   .FoodCategories
					   .Where(x => x.FoodId == foodId)
					   .Select(x => x.CategoryId)
					   .ToList();
		}

		public EntityEntry<Food> Create(string name, int typeId,
										bool glutenFree = true)
		{
			if (string.IsNullOrEmpty(name) ||
				typeId < 1) {
				return null;
			}
			var f = new Food() {
				Name = name,
				TypeId = typeId,
				GlutenFree = glutenFree,
			};

			return Create(f);
		}
	}
}