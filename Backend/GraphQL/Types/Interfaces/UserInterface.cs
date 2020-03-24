using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using GraphQL.Types;

namespace Backend.GraphQL.Types.Interfaces
{
	public class UserInterface : InterfaceGraphType<User>
	{
		public UserInterface()
		{
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property");
			Field(x => x.Firstname, type: typeof(StringGraphType)).Description("Firstname");
			Field(x => x.Lastname, type: typeof(StringGraphType)).Description("Lastname");
			Field(x => x.CreatedAt, type: typeof(DateTimeGraphType)).Description("Created at");
		}
	}
}