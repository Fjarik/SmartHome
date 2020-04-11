using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.IRepositories;
using DataService.IServices;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Enums;
using SharedLibrary.Interfaces;
using SharedLibrary.Objects;

namespace DataService.Services
{
	public abstract class BaseService<TEntity, TRepository> : IBaseService<TEntity, TRepository>
		where TEntity : class, IDbEntity
		where TRepository : IBaseRepository<TEntity>
	{
		public TRepository Repository { get; }

		protected BaseService(TRepository repository)
		{
			this.Repository = repository;
		}

		public HomeResult<TEntity> GetById(int id)
		{
			if (id < 1) {
				return new HomeResult<TEntity>(StatusCode.NotValidId);
			}
			var ent = this.Repository.GetById(id);
			return new HomeResult<TEntity>(StatusCode.OK, ent);
		}

		public ILookup<int, TEntity> GetLookupByIds(IEnumerable<int> ids)
		{
			return this.Repository.GetLookupByIds(ids);
		}

		public virtual List<TEntity> GetAll()
		{
			return this.Repository.GetAll();
		}
	}
}