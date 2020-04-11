using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedLibrary.Interfaces;

namespace DataAccess.IRepositories
{
	public interface IBaseRepository<TEntity> where TEntity : class, IDbEntity
	{
		List<TEntity> GetAll();
		TEntity GetById(int id);
		ILookup<int, TEntity> GetLookupByIds(IEnumerable<int> ids);

		EntityEntry<TEntity> Create(TEntity entity);
		bool Delete(TEntity entity);

		int Save(TEntity entity);
		int Save();
	}
}