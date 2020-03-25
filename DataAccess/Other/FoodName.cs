using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Other
{
	internal class FoodName
	{
		public string Name { get; set; }
		public int Type { get; set; }
		public int Category { get; set; }

		public List<int> FoodSides { get; } = new List<int>();

		public FoodName() { }

		public FoodName(params int[] sides)
		{
			this.FoodSides = sides.ToList();
		}
	}
}