using System;
using System.Collections.Generic;
using System.Text;

namespace DataService
{
	public class AppSettings
	{
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public string Secret { get; set; }
		public int ExpirationHours { get; set; }
	}
}