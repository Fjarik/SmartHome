using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using SharedLibrary.Interfaces;
using SharedLibrary.Objects;

namespace DataAccess.Other
{
	public class AuthUser : User
	{
		public AuthToken AuthToken { get; set; }

		public AuthUser() { }

		public AuthUser(User u, IAuthToken token)
		{
			this.Id = u.Id;
			this.GoogleId = u.GoogleId;
			this.Email = u.Email;
			this.Firstname = u.Firstname;
			this.Lastname = u.Lastname;
			this.CreatedAt = u.CreatedAt;
			this.AuthToken = new AuthToken(token);
		}
	}
}