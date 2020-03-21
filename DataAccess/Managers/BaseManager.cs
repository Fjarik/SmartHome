using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.IManagers;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;

namespace DataAccess.Managers
{
	public abstract class BaseManager<TEntity> : IBaseManager<TEntity> where TEntity : class, IDbEntity
	{
		public MainContext DbContext { get; }

		protected BaseManager(MainContext dbContext)
		{
			DbContext = dbContext;
		}

		public Task<List<TEntity>> GetAllAsync()
		{
			return DbContext.Set<TEntity>().ToListAsync();
		}
	}
}