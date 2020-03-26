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
	public interface IFoodService : IBaseService<Food, IFoodRepository>
	{
		Task<bool> ExistsAsync(string name, CancellationToken cancellationToken);

		Task<List<Category>> GetCategoriesAsync(int foodId, CancellationToken cancellationToken);

		Task<HomeResult<Food>> CreateAsync(string name, int typeId, IList<int> categories,
										   CancellationToken cancellationToken,
										   bool glutenFree = true);
	}
}