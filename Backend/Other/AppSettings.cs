﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Other
{
	public class AppSettings
	{
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public string Secret { get; set; }
	}
}