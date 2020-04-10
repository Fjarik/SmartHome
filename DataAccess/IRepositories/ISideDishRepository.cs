using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.IRepositories
{
	public interface ISideDishRepository : IBaseRepository<SideDish>
	{
		bool Exists(string name);
		EntityEntry<SideDish> Create(string name, string description = null, bool glutenFree = true);
	}
}