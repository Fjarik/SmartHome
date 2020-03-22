using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;

namespace DataAccess.Repositories
{
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IDbEntity
	{
		public MainContext DbContext { get; }

		protected BaseRepository(MainContext dbContext)
		{
			DbContext = dbContext;
		}

		public Task<List<TEntity>> GetAllAsync()
		{
			return DbContext.Set<TEntity>().ToListAsync();
		}
	}
}