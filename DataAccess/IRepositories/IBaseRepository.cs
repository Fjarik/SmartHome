using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using SharedLibrary.Interfaces;

namespace DataAccess.IRepositories
{
	public interface IBaseRepository<TEntity> where TEntity : class, IDbEntity
	{
		MainContext DbContext { get; }

		Task<List<TEntity>> GetAllAsync();
	}
}