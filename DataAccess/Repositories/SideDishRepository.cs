using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Contexts;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repositories
{
	public class SideDishRepository : BaseRepository<SideDish>, ISideDishRepository
	{
		public SideDishRepository(MainContext dbContext) : base(dbContext) { }

		public bool Exists(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return false;
			}
			return this.DbSet.Any(x => x.Name == name);
		}

		public EntityEntry<SideDish> Create(string name, string description = null, bool glutenFree = true)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return null;
			}

			var side = new SideDish {
				Name = name,
				Description = description,
				GlutenFree = glutenFree
			};
			return Create(side);
		}
	}
}