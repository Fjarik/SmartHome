using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using SharedLibrary.Enums;
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
		public FoodTypes Type => (FoodTypes) this.TypeId;

		[NotMapped]
		public IEnumerable<int> CategoryIds => this.FoodCategories.Select(x => x.CategoryId).Distinct();
	}

	public partial class Meal : IDbEntity
	{
		[NotMapped]
		public MealTypes Type => (MealTypes) this.TypeId;
	}

	public partial class Token : IDbEntity
	{
		[NotMapped]
		public bool IsValid => this.Expiration > DateTime.Now;
	}

	public partial class User : IDbEntity { }
}