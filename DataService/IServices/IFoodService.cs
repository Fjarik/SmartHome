using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using SharedLibrary.Enums;
using SharedLibrary.Objects;

namespace DataService.IServices
{
	public interface IFoodService : IBaseService<Food, IFoodRepository>
	{
		bool Exists(string name);

		List<Category> GetCategories(int foodId);

		List<Food> GetByTypes(params FoodTypes[] types);
		List<Food> GetByTypes(params int[] ids);

		HomeResult<Food> Create(FoodInput input);

		HomeResult<Food> Create(string name, FoodTypes type,
								List<int> categoryIds,
								List<int> sideIds,
								bool glutenFree = true);

		HomeResult<Food> Create(string name, int typeId,
								List<int> categoryIds,
								List<int> sideIds,
								bool glutenFree = true);
	}
}