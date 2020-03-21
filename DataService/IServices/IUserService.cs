using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.IManagers;
using DataAccess.Models;

namespace DataService.IServices
{
	public interface IUserService : IBaseService<User, IUserManager> { }
}