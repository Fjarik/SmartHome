using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.IRepositories
{
	public interface ICategoryRepository : IBaseRepository<Category>
	{
		bool Exists(string name);
		List<Category> GetByIds(IEnumerable<int> ids);
		EntityEntry<Category> Create(string name, string description, bool isHealthy = false);
	}
}