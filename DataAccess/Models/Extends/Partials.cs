using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using SharedLibrary.Interfaces;

namespace DataAccess.Models
{
	public partial class Category : IDbEntity
	{
		[NotMapped]
		public IEnumerable<int> FoodIds => this.FoodCategories.Select(x => x.FoodId).Distinct();
	}

	public partial class Food : IDbEntity
	{
		[NotMapped]
		public IEnumerable<int> CategoryIds => this.FoodCategories.Select(x => x.CategoryId).Distinct();
	}

	public partial class FoodType : IDbEntity { }

	public partial class Meal : IDbEntity { }

	public partial class MealType : IDbEntity { }

	public partial class Token : IDbEntity
	{
		[NotMapped]
		public bool IsValid => this.Expiration > DateTime.Now;
	}

	public partial class User : IDbEntity { }
}