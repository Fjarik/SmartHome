﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using SharedLibrary.Interfaces;
using SharedLibrary.Objects;

namespace DataService.IServices
{
	public interface IBaseService<TEntity, out TRepository>
		where TEntity : class, IDbEntity where TRepository : IBaseRepository<TEntity>
	{
		TRepository Repository { get; }

		Task<HomeResult<TEntity>> GetByIdAsync(int id);
		Task<List<TEntity>> GetAllAsync();
	}
}