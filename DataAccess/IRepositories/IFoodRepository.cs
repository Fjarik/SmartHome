using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.IRepositories
{
	public interface IFoodRepository : IBaseRepository<Food>
	{
		bool Exists(string name);
		List<int> GetCategoryIds(int foodId);
		List<Food> GetByTypes(params int[] ids);
		EntityEntry<Food> Create(string name, int typeId, bool glutenFree = true);
		List<FoodCategory> CreateFoodCategories(int foodId, IEnumerable<int> categoryIds);
	}
}