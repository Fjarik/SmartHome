using System;
using System.Collections.Generic;
using System.Text;
using SharedLibrary.Enums;

namespace SharedLibrary.Objects
{
	public class MealInput
	{
		public DateTime Date { get; set; }
		public MealTypes Type { get; set; }
		public MealTimes Time { get; set; } = MealTimes.Lunch;

		public int? FoodId { get; set; } = null;
		public int? SoupId { get; set; } = null;
		public int? SideDishId { get; set; } = null;
		public int? OriginalMealId { get; set; } = null;

		public bool IsValid => (FoodId > 0 || FoodId == null) &&
							   (SoupId > 0 || SoupId == null) &&
							   (SideDishId > 0 || SideDishId == null) &&
							   (OriginalMealId > 0 || OriginalMealId == null);
	}
}