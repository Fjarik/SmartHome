﻿using System;
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
		public IEnumerable<int> FoodIds => this.FoodCategories.Select(x => x.FoodId);
	}

	public partial class Food : IDbEntity
	{
		[NotMapped]
		public FoodTypes Type => (FoodTypes) this.TypeId;

		[NotMapped]
		public IEnumerable<int> CategoryIds => this.FoodCategories.Select(x => x.CategoryId);

		[NotMapped]
		public IEnumerable<int> SideIds => this.FoodSideFoods.Select(x => x.SideId);
	}

	public partial class Meal : IDbEntity
	{
		[NotMapped]
		public IEnumerable<int> CategoryIds => this.MealCategories.Select(x => x.CategoryId);

		[NotMapped]
		public MealTypes Type => (MealTypes) this.TypeId;

		[NotMapped]
		public MealTimes Time => (MealTimes) this.TimeId;

		[NotMapped]
		public bool IsRemoveable => this.OriginalMealId != null;
	}

	public partial class Token : IDbEntity, IAuthToken
	{
		[NotMapped]
		public bool IsValid => this.Expiration > DateTime.Now;

		[NotMapped]
		public string RefreshToken => Convert.ToBase64String(this.RefreshTokenBytes);
	}

	public partial class User : IDbEntity { }
}