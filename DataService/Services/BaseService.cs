using System;
using System.Collections.Generic;
using System.Text;
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

		public async Task<HomeResult<TEntity>> GetByIdAsync(int id)
		{
			if (id < 1) {
				return new HomeResult<TEntity>(StatusCode.NotValidId);
			}
			var ent = await this.Repository.GetByIdAsync(id);
			return new HomeResult<TEntity>(StatusCode.OK, ent);
		}

		public virtual Task<List<TEntity>> GetAllAsync()
		{
			return this.Repository.GetAllAsync();
		}
	}
}