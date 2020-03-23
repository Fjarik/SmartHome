using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;

namespace DataAccess.Contexts
{
	public partial class MainContext
	{
		public MainContext()
		{
			this.Database.EnsureCreated();
		}

		public MainContext(DbContextOptions<MainContext> options)
			: base(options)
		{
			this.Database.EnsureCreated();
		}
	}
}