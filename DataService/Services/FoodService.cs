using System;
using System.Collections.Generic;
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

		public async Task<HomeResult<Food>> CreateAsync(string name, int categoryId, int typeId)
		{
			if (string.IsNullOrEmpty(name) ||
				categoryId < 1 ||
				typeId < 1) {
				return new HomeResult<Food>(StatusCode.InvalidInput);
			}


			if (await this.ExistsAsync(name)) {
				return new HomeResult<Food>(StatusCode.AlreadyExists);
			}

			var u = await this.Repository.CreateAsync(name, categoryId, typeId);
			if (u?.Entity == null) {
				return new HomeResult<Food>(StatusCode.InternalError);
			}
			return new HomeResult<Food>(StatusCode.OK, u.Entity);
		}
	}
}