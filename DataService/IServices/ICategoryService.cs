using System;
using System.Collections.Generic;
using System.Linq;
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
		bool Exists(string name);
		List<Category> GetByIds(IList<int> ids);

		HomeResult<Category> Create(string name, string description,
									bool isHealthy = false);
	}
}