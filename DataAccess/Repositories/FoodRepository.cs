﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repositories
{
	public class FoodRepository : BaseRepository<Food>, IFoodRepository
	{
		public FoodRepository(MainContext dbContext) : base(dbContext) { }

		public async Task<bool> ExistsAsync(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return false;
			}
			return await this.DbSet.AnyAsync(x => x.Name == name);
		}

		public async ValueTask<EntityEntry<Food>> CreateAsync(string name, int typeId, bool glutenFree = true)
		{
			if (string.IsNullOrEmpty(name) ||
				typeId < 1) {
				return null;
			}
			var f = new Food() {
				Name = name,
				TypeId = typeId,
				GlutenFree = glutenFree,
			};

			return await CreateAsync(f);
		}
	}
}