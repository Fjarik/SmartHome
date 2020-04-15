using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Other;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;

namespace DataAccess.Contexts
{
	public partial class MainContext
	{
		public MainContext()
		{
			//this.Database.EnsureCreated();
		}

		public MainContext(DbContextOptions<MainContext> options)
			: base(options)
		{
			//this.Database.EnsureCreated();
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
		{
			// dotnet ef migrations add InitialCreate --project DataAccess --startup-project Backend
			modelBuilder.Entity<Category>().Seed();
			modelBuilder.Entity<Food>().SeedSides();
			modelBuilder.Entity<Food>().Seed();
			modelBuilder.Entity<FoodSide>().Seed();
			modelBuilder.Entity<FoodCategory>().Seed();
		}
	}
}