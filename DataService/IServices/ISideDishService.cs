using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.IRepositories;
using DataAccess.Models;
using SharedLibrary.Objects;

namespace DataService.IServices
{
	public interface ISideDishService : IBaseService<SideDish, ISideDishRepository>
	{
		bool Exists(string name);
		HomeResult<SideDish> Create(string name, string description = null, bool glutenFree = true);
	}
}