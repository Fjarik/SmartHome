using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.IRepositories
{
	public interface IFoodRepository : IBaseRepository<Food>
	{
		Task<bool> ExistsAsync(string name);
		ValueTask<EntityEntry<Food>> CreateAsync(string name, int categoryId, int typeId);
	}
}