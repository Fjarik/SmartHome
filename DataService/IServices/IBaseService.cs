using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.IManagers;
using SharedLibrary.Interfaces;

namespace DataService.IServices
{
	public interface IBaseService<TEntity, out TManager>
		where TEntity : class, IDbEntity where TManager : IBaseManager<TEntity>
	{
		TManager Manager { get; }

		Task<List<TEntity>> GetAllAsync();
	}
}