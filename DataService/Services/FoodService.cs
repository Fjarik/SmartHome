using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.IRepositories;
using DataAccess.Models;
using DataService.IServices;
using SharedLibrary.Enums;
using SharedLibrary.Objects;

namespace DataService.Services
{
	public class FoodService : BaseService<Food, IFoodRepository>, IFoodService
	{
		public FoodService(IFoodRepository repository) : base(repository) { }

		public async Task<bool> ExistsAsync(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return false;
			}
			return await this.Repository.ExistsAsync(name);
		}

		public async Task<HomeResult<Food>> CreateAsync(string name, int typeId, IList<int> categories,
														bool glutenFree = true)
		{
			if (string.IsNullOrEmpty(name) ||
				!categories.Any() ||
				categories.Any(x => x < 1) ||
				typeId < 1) {
				return new HomeResult<Food>(StatusCode.InvalidInput);
			}


			if (await this.ExistsAsync(name)) {
				return new HomeResult<Food>(StatusCode.AlreadyExists);
			}

			var u = await this.Repository.CreateAsync(name, typeId, glutenFree);
			if (u?.Entity == null) {
				return new HomeResult<Food>(StatusCode.InternalError);
			}

			// TODO: Create food categories

			return new HomeResult<Food>(StatusCode.OK, u.Entity);
		}
	}
}