using System;
using System.Collections.Generic;
using System.Text;
using SharedLibrary.Enums;

namespace SharedLibrary.Objects
{
	public class FoodInput
	{
		public string Name { get; set; }
		public FoodTypes Type { get; set; }
		public IList<int> Categories { get; set; } = new List<int>();
		public bool GlutenFree { get; set; } = true;

		public bool IsValid => !string.IsNullOrWhiteSpace(this.Name);
	}
}