using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using SharedLibrary.Objects;

namespace DataService.IServices
{
	public interface IFoodService : IBaseService<Food, IFoodRepository>
	{
		Task<bool> ExistsAsync(string name);
		Task<HomeResult<Food>> CreateAsync(string name, int categoryId, int typeId);
	}
}