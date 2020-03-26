using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.IRepositories
{
	public interface ICategoryRepository : IBaseRepository<Category>
	{
		Task<bool> ExistsAsync(string name, CancellationToken cancellationToken);
		Task<List<Category>> GetByIdsAsync(IList<int> ids, CancellationToken cancellationToken);

		ValueTask<EntityEntry<Category>> CreateAsync(string name, string description,
													 CancellationToken cancellationToken,
													 bool isHealthy = false);
	}
}