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
	public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(MainContext dbContext) : base(dbContext) { }

		public async Task<bool> ExistsAsync(string name, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return false;
			}
			return await this.DbSet.AnyAsync(x => x.Name == name, cancellationToken);
		}

		public async Task<List<Category>> GetByIdsAsync(IList<int> ids, CancellationToken cancellationToken)
		{
			if (!ids.Any()) {
				return new List<Category>();
			}
			return await this.DbSet.Where(x => ids.Any(y => y == x.Id)).ToListAsync(cancellationToken);
		}

		public async ValueTask<EntityEntry<Category>> CreateAsync(string name,
																  string description,
																  CancellationToken cancellationToken,
																  bool isHealthy = false)
		{
			if (string.IsNullOrEmpty(name) ||
				string.IsNullOrEmpty(description)) {
				return null;
			}
			var c = new Category() {
				Name = name,
				Description = description,
				IsHealthy = isHealthy,
			};

			return await CreateAsync(c, cancellationToken);
		}
	}
}