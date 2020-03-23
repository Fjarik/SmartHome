using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedLibrary.Interfaces;

namespace DataAccess.Repositories
{
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IDbEntity
	{
		protected MainContext DbContext { get; }

		protected DbSet<TEntity> DbSet => this.DbContext.Set<TEntity>();

		protected BaseRepository(MainContext dbContext)
		{
			DbContext = dbContext;
		}

		public virtual Task<List<TEntity>> GetAllAsync()
		{
			return this.DbSet.ToListAsync();
		}

		public virtual Task<TEntity> GetByIdAsync(int id)
		{
			return this.DbSet.FirstOrDefaultAsync(x => x.Id == id);
		}

		public virtual async ValueTask<EntityEntry<TEntity>> CreateAsync(TEntity entity)
		{
			var ent = await this.DbSet.AddAsync(entity);
			await this.SaveAsync();
			return ent;
		}

		public virtual async Task<bool> DeleteAsync(TEntity entity)
		{
			try {
				this.DbSet.Remove(entity);
				await this.DbContext.SaveChangesAsync();
			} catch {
				return false;
			}
			return true;
		}

		public virtual Task<int> SaveAsync(TEntity entity)
		{
			if (entity != null) {
				this.DbSet.Update(entity);
			}
			return this.SaveAsync();
		}

		public virtual Task<int> SaveAsync()
		{
			return this.DbContext.SaveChangesAsync();
		}
	}
}