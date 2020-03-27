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

		public override List<Category> GetAll()
		{
			return this.DbSet
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

		public List<Category> GetByIds(IList<int> ids)
		{
			if (!ids.Any()) {
				return new List<Category>();
			}
			return this.DbSet.Where(x => ids.Contains(x.Id)).ToList();
		}

		public EntityEntry<Category> Create(string name,
											string description,
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

			return Create(c);
		}
	}
}