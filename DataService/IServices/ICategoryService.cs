using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using SharedLibrary.Objects;

namespace DataService.IServices
{
	public interface ICategoryService : IBaseService<Category, ICategoryRepository>
	{
		Task<bool> ExistsAsync(string name, CancellationToken cancellationToken);
		Task<List<Category>> GetByIdsAsync(IList<int> ids, CancellationToken cancellationToken);

		Task<HomeResult<Category>> CreateAsync(string name, string description, CancellationToken cancellationToken,
											   bool isHealthy = false);
	}
}