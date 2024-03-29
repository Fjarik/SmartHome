﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

		HomeResult<TEntity> GetById(int id);
		ILookup<int, TEntity> GetLookupByIds(IEnumerable<int> ids);
		List<TEntity> GetAll();
		bool Delete(int id);
		bool Delete(TEntity entity);
	}
}