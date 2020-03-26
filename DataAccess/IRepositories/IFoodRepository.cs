﻿using System;
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
		Task<bool> ExistsAsync(string name, CancellationToken cancellationToken);
		Task<List<int>> GetCategoryIdsAsync(int foodId, CancellationToken cancellationToken);

		ValueTask<EntityEntry<Food>> CreateAsync(string name, int typeId, CancellationToken cancellationToken,
												 bool glutenFree = true);
	}
}