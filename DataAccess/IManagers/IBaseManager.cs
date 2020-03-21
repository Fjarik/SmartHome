using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using SharedLibrary.Interfaces;

namespace DataAccess.IManagers
{
	public interface IBaseManager<TEntity> where TEntity : class, IDbEntity
	{
		MainContext DbContext { get; }

		Task<List<TEntity>> GetAllAsync();
	}
}