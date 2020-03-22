using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SharedLibrary.Interfaces;

namespace DataAccess.Models
{
	public partial class Food : IDbEntity { }

	public partial class FoodCategory : IDbEntity { }

	public partial class FoodType : IDbEntity { }

	public partial class Meal : IDbEntity { }

	public partial class MealType : IDbEntity { }

	public partial class Relationship : IDbEntity { }

	public partial class Token : IDbEntity { }

	public partial class User : IDbEntity
	{
		[NotMapped]
		public string AuthToken { get; set; }
	}
}