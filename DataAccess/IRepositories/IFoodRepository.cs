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
		List<FoodCategory> CreateFoodCategories(int foodId, List<int> categoryIds);
		bool RemoveFoodCategories(int foodId, List<int> categoryIds);
		List<FoodSide> CreateFoodSides(int foodId, List<int> sideIds);
		bool RemoveFoodSides(int foodId, List<int> sideIds);
	}
}