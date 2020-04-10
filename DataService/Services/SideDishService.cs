using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.IRepositories;
using DataAccess.Models;
using DataService.IServices;
using SharedLibrary.Enums;
using SharedLibrary.Objects;

namespace DataService.Services
{
	public class SideDishService : BaseService<SideDish, ISideDishRepository>, ISideDishService
	{
		public SideDishService(ISideDishRepository repository) : base(repository) { }

		public bool Exists(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return false;
			}
			return this.Repository.Exists(name);
		}

		public HomeResult<SideDish> Create(string name, string description = null, bool glutenFree = true)
		{
			if (string.IsNullOrWhiteSpace(name)) {
				return new HomeResult<SideDish>(StatusCode.InvalidInput);
			}
			if (this.Exists(name)) {
				return new HomeResult<SideDish>(StatusCode.AlreadyExists);
			}
			var res = this.Repository.Create(name, description, glutenFree);
			if (res?.Entity == null) {
				return new HomeResult<SideDish>(StatusCode.InternalError);
			}
			return new HomeResult<SideDish>(StatusCode.OK, res.Entity);
		}
	}
}