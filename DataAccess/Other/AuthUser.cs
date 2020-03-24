using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace DataAccess.Other
{
	public class AuthUser : User
	{
		public string AuthToken { get; set; }

		public AuthUser() { }

		public AuthUser(User u)
		{
			this.Id = u.Id;
			this.GoogleId = u.GoogleId;
			this.Email = u.Email;
			this.Firstname = u.Firstname;
			this.Lastname = u.Lastname;
			this.CreatedAt = u.CreatedAt;
			this.Meals = u.Meals;
			this.RelationshipSources = u.RelationshipSources;
			this.RelationshipTargets = u.RelationshipTargets;
			this.Tokens = u.Tokens;
		}
	}
}