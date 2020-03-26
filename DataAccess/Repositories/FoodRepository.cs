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

		public override Task<List<Food>> GetAllAsync(CancellationToken cancellationToken)
		{
			return this.DbSet
					   .Include(x => x.Type) // TODO: Edit
					   .ToListAsync(cancellationToken);
		}

		public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return false;
			}
			return await this.DbSet.AnyAsync(x => x.Name == name, cancellationToken);
		}

		public async Task<List<int>> GetCategoryIdsAsync(int foodId, CancellationToken cancellationToken)
		{
			if (foodId < 1) {
				return new List<int>();
			}
			return await this.DbContext
							 .FoodCategories
							 .Where(x => x.FoodId == foodId)
							 .Select(x => x.CategoryId)
							 .ToListAsync(cancellationToken);
		}

		public async ValueTask<EntityEntry<Food>> CreateAsync(string name, int typeId,
															  CancellationToken cancellationToken,
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

			return await CreateAsync(f, cancellationToken);
		}
	}
}