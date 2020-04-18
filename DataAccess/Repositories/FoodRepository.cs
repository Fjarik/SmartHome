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

		private IQueryable<Food> _all => this.DbSet
											 .Include(x => x.FoodCategories)
											 .Include(x => x.FoodSideFoods);

		public override Food GetById(int id)
		{
			return this._all.FirstOrDefault(x => x.Id == id);
		}

		public override List<Food> GetAll()
		{
			return this._all.ToList();
		}

		public bool Exists(string name)
		{
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

		public List<Food> GetByTypes(params int[] ids)
		{
			var types = ids.Distinct();
			return this._all
					   .Where(x => types.Contains(x.TypeId))
					   .ToList();
		}

		public EntityEntry<Food> Create(string name, int typeId,
										bool glutenFree = true)
		{
			var f = new Food() {
				Name = name,
				TypeId = typeId,
				GlutenFree = glutenFree,
			};

			return Create(f);
		}

		public List<FoodCategory> CreateFoodCategories(int foodId, List<int> categoryIds)
		{
			if (!categoryIds.Any()) {
				return new List<FoodCategory>();
			}

			var foodCategories = categoryIds.Select(categoryId => new FoodCategory {
				FoodId = foodId,
				CategoryId = categoryId
			});

			this.DbContext.FoodCategories.AddRange(foodCategories);
			this.Save();

			return this.DbContext
					   .FoodCategories
					   .Where(x => x.FoodId == foodId)
					   .ToList();
		}

		public bool RemoveFoodCategories(int foodId, List<int> categoryIds)
		{
			if (!categoryIds.Any()) {
				return false;
			}

			var res = this.DbContext.FoodCategories
						  .Where(x => x.FoodId == foodId &&
									  categoryIds.Contains(x.CategoryId))
						  .DeleteFromQuery();

			return res > 0;
		}

		public List<FoodSide> CreateFoodSides(int foodId, List<int> sideIds)
		{
			if (!sideIds.Any()) {
				return new List<FoodSide>();
			}

			var foodSides = sideIds.Select(sideId => new FoodSide {
				FoodId = foodId,
				SideId = sideId,
			});

			this.DbContext.FoodSides.AddRange(foodSides);
			this.Save();

			return this.DbContext
					   .FoodSides
					   .Where(x => x.FoodId == foodId)
					   .ToList();
		}

		public bool RemoveFoodSides(int foodId, List<int> sideIds)
		{
			if (!sideIds.Any()) {
				return false;
			}

			var res = this.DbContext
						  .FoodSides
						  .Where(x => x.FoodId == foodId &&
									  sideIds.Contains(x.SideId))
						  .DeleteFromQuery();

			return res > 0;
		}
	}
}