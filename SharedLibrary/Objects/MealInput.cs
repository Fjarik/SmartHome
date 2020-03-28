using System;
using System.Collections.Generic;
using System.Text;
using SharedLibrary.Enums;

namespace SharedLibrary.Objects
{
	public class MealInput
	{
		public int CookedById { get; set; }
		public int FoodId { get; set; }
		public MealTypes Type { get; set; }
		public DateTime Date { get; set; }

		public bool IsValid => CookedById > 0 &&
							   FoodId > 0;
	}
}