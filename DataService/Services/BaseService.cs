using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.IManagers;
using DataService.IServices;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;

namespace DataService.Services
{
	public abstract class BaseService<TEntity, TManager> : IBaseService<TEntity, TManager>
		where TEntity : class, IDbEntity
		where TManager : IBaseManager<TEntity>
	{
		public TManager Manager { get; }

		protected BaseService(TManager mgr)
		{
			this.Manager = mgr;
		}

		public virtual Task<List<TEntity>> GetAllAsync()
		{
			return this.Manager.GetAllAsync();
		}
	}
}