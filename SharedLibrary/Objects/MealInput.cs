using System;
using System.Collections.Generic;
using System.Text;
using SharedLibrary.Enums;

namespace SharedLibrary.Objects
{
	public class MealInput
	{
		public int FoodId { get; set; }
		public MealTypes Type { get; set; }
		public DateTime Date { get; set; }
		public int? SideDishId { get; set; } = null;
		public int? OriginalMealId { get; set; } = null;

		public bool IsValid => FoodId > 0 &&
							   (SideDishId == null ||
								(SideDishId != null && SideDishId > 1)) &&
							   (OriginalMealId == null ||
								(OriginalMealId != null && OriginalMealId > 1));
	}
}