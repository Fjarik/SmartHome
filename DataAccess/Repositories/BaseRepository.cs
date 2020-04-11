using System;
using System.Collections.Generic;
using System.Linq;
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

		protected virtual DbSet<TEntity> DbSet => this.DbContext.Set<TEntity>();

		protected BaseRepository(MainContext dbContext)
		{
			DbContext = dbContext;
		}

		public virtual List<TEntity> GetAll()
		{
			return this.DbSet.ToList();
		}

		public virtual TEntity GetById(int id)
		{
			return this.DbSet.FirstOrDefault(x => x.Id == id);
		}

		public ILookup<int, TEntity> GetLookupByIds(IEnumerable<int> ids)
		{
			var ents = this.DbSet.Where(x => ids.Contains(x.Id)).ToList();
			return ents.ToLookup(x => x.Id);
		}

		public virtual EntityEntry<TEntity> Create(TEntity entity)
		{
			var ent = this.DbSet.Add(entity);
			this.Save();
			return ent;
		}

		public virtual bool Delete(TEntity entity)
		{
			try {
				this.DbSet.Remove(entity);
				this.Save();
			} catch {
				return false;
			}
			return true;
		}

		public virtual int Save(TEntity entity)
		{
			if (entity != null) {
				this.DbSet.Update(entity);
			}
			return this.Save();
		}

		public virtual int Save()
		{
			return this.DbContext.SaveChanges();
		}
	}
}