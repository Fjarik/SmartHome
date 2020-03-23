using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedLibrary.Interfaces;

namespace DataAccess.IRepositories
{
	public interface IBaseRepository<TEntity> where TEntity : class, IDbEntity
	{
		Task<List<TEntity>> GetAllAsync();
		Task<TEntity> GetByIdAsync(int id);

		ValueTask<EntityEntry<TEntity>> CreateAsync(TEntity entity);
		Task<bool> DeleteAsync(TEntity entity);

		Task<int> SaveAsync(TEntity entity);
		Task<int> SaveAsync();
	}
}