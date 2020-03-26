using System;
using System.Collections.Generic;
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
		Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
		Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);

		ValueTask<EntityEntry<TEntity>> CreateAsync(TEntity entity, CancellationToken cancellationToken);
		Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);

		Task<int> SaveAsync(TEntity entity, CancellationToken cancellationToken);
		Task<int> SaveAsync(CancellationToken cancellationToken);
	}
}