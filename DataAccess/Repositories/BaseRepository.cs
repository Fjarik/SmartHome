using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

		public virtual Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return this.DbSet.ToListAsync(cancellationToken);
		}

		public virtual Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return this.DbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
		}

		public virtual async ValueTask<EntityEntry<TEntity>> CreateAsync(
			TEntity entity, CancellationToken cancellationToken)
		{
			var ent = await this.DbSet.AddAsync(entity, cancellationToken);
			await this.SaveAsync(cancellationToken);
			return ent;
		}

		public virtual async Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
		{
			try {
				this.DbSet.Remove(entity);
				await this.DbContext.SaveChangesAsync(cancellationToken);
			} catch {
				return false;
			}
			return true;
		}

		public virtual Task<int> SaveAsync(TEntity entity, CancellationToken cancellationToken)
		{
			if (entity != null) {
				this.DbSet.Update(entity);
			}
			return this.SaveAsync(cancellationToken);
		}

		public virtual Task<int> SaveAsync(CancellationToken cancellationToken)
		{
			return this.DbContext.SaveChangesAsync(cancellationToken);
		}
	}
}