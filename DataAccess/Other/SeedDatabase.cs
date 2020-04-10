using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Other
{
	public static class SeedDatabase
	{
		private static FoodName[] FoodNames => new[] {
			new FoodName(1, 2) {Name = "Kotlety na cibulce", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1) {Name = "Ražniči", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1, 6) {Name = "Naložené kuřecí plátky", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1, 6) {Name = "Naložené vepřové plátky", Type = 1, Categories = new[] {3, 5},},
			new FoodName(3) {Name = "Knedlo, vepřo, zelo", Type = 1, Categories = new[] {3, 5},},
			new FoodName(3) {Name = "Knedlo, vepřo, špenát", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1) {Name = "Špenát s vajíčkem", Type = 1, Categories = new[] {2, 5},},
			new FoodName(1, 2, 6) {Name = "Řízky", Type = 1, Categories = new[] {3, 4},},
			new FoodName(1, 2) {Name = "Filé", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1, 2) {Name = "Sekaná", Type = 1, Categories = new[] {3, 5},},
			new FoodName() {Name = "Rizoto kuřecí", Type = 1, Categories = new[] {3, 5},},
			new FoodName() {Name = "Rizoto vepřové", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1, 3) {Name = "Kuře na papirce", Type = 1, Categories = new[] {3, 5, 9},},
			new FoodName(1, 3) {Name = "Rajská", Type = 1, Categories = new[] {3, 5, 9},},
			new FoodName(1, 5) {Name = "Guláš", Type = 1, Categories = new[] {3, 6, 9},},
			new FoodName(1) {Name = "Buřt guláš", Type = 1, Categories = new[] {3, 6, 9},},
			new FoodName(1, 2, 4) {Name = "Ptáčky", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1) {Name = "Houbová omáčka", Type = 1, Categories = new[] {3, 6, 9},},
			new FoodName(1, 3) {Name = "Koprovka", Type = 1, Categories = new[] {2, 6},},
			new FoodName() {Name = "Šunkafleky", Type = 1, Categories = new[] {3, 5},},
			new FoodName() {Name = "Zapečné brambory", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1, 6) {Name = "Maso ve smetanové omáčce", Type = 1, Categories = new[] {3, 5, 9},},
			new FoodName(1, 6) {Name = "Maso zapečené s kečupem", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1) {Name = "Kuře s nádivkou", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1, 2, 7, 8) {Name = "Klobása", Type = 1, Categories = new[] {3, 5, 7},},
			new FoodName(1, 2, 6) {Name = "Kuřecí kapsa", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1, 6) {Name = "Smažený sýr", Type = 1, Categories = new[] {3, 4},},
			new FoodName(1, 6) {Name = "Žampiony", Type = 1, Categories = new[] {2, 4, 5},},
			new FoodName(1, 6) {Name = "Květák", Type = 1, Categories = new[] {2, 4},},
			new FoodName(1, 2) {Name = "Holandký řízek", Type = 1, Categories = new[] {3, 5},},
			new FoodName() {Name = "Halušky", Type = 1, Categories = new[] {3, 5},},
			new FoodName() {Name = "Špagety", Type = 1, Categories = new[] {3, 6},},
			new FoodName() {Name = "Těstoviny stuňákem", Type = 1, Categories = new[] {3, 6},},
			new FoodName() {Name = "Bramboráky", Type = 1, Categories = new[] {2, 4},},
			new FoodName(1, 2, 4, 6) {Name = "Roláda kuřecí", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1, 2, 4, 6) {Name = "Roláda vepřová", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1) {Name = "Dušení mrkev + maso", Type = 1, Categories = new[] {3, 5, 8},},
			new FoodName() {Name = "Čína", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1, 2) {Name = "Karbanátky", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1, 2) {Name = "Čevabčiči", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1, 2, 4, 6) {Name = "Kuřecí plátek v alobalu", Type = 1, Categories = new[] {3, 5},},
			new FoodName(1, 2, 6) {Name = "Johančino tajemství", Type = 1, Categories = new[] {3, 5},},
			new FoodName(7) {Name = "Čočka na kyselo", Type = 1, Categories = new[] {3, 6},},
			new FoodName(1, 7) {Name = "Míchaná zelenina", Type = 1, Categories = new[] {2, 5},},
			new FoodName(1, 7) {Name = "Pečené maso", Type = 1, Categories = new[] {3, 5},},
			new FoodName() {Name = "Buřtgulášová polévka", Type = 2, Categories = new[] {3},},
			new FoodName() {Name = "Česnečka", Type = 2, Categories = new[] {2},},
			new FoodName() {Name = "Bramboračka", Type = 2, Categories = new[] {2},},
			new FoodName() {Name = "Pórková polévka", Type = 2, Categories = new[] {2},},
			new FoodName() {Name = "Houbová polévka", Type = 2, Categories = new[] {2},},
			new FoodName() {Name = "Polévka z kuřecího vývaru", Type = 2, Categories = new[] {3},},
			new FoodName() {Name = "Špenátová polévka", Type = 2, Categories = new[] {2},},
		};

		public static void Seed(this EntityTypeBuilder<Category> builder)
		{
			var types = new[] {
				new Category {
					Name = "Sladké", // 1
					Description = "Všechna sladká jídla",
					IsHealthy = false,
				},
				new Category {
					Name = "Bezmasé", // 2
					Description = "Jídla, která neobsahují maso",
					IsHealthy = true,
				},
				new Category {
					Name = "S masem", // 3
					Description = "Jídla s libovolným obsahem jakéhokoliv masa",
					IsHealthy = null,
				},
				new Category {
					Name = "Smažené", // 4
					Description = "Jídla, která byla upravena procesem smažením",
					IsHealthy = false,
				},
				new Category {
					Name = "Pečené", // 5
					Description = "Jídla, která byla upravena procesem upečením",
					IsHealthy = null,
				},
				new Category {
					Name = "Vařené", // 6
					Description = "Jídla, která byla upravena procesem vařením",
					IsHealthy = null,
				},
				new Category {
					Name = "Grilované", // 7
					Description = "Jídla, která byla upravena procesem grilováním",
					IsHealthy = false,
				},
				new Category {
					Name = "Dušené", // 8
					Description = "Jídla, která byla upravena procesem dušením",
					IsHealthy = true,
				},
				new Category {
					Name = "S omáčkou", // 9
					Description = "Jídla, která jsou servírována s omáčkou",
					IsHealthy = null,
				},
				new Category {
					Name = "Se sosem", // 10
					Description = "Jídla, která jsou servírována se sosem",
					IsHealthy = null,
				},
			};

			for (var i = 0; i < types.Length; i++) {
				types[i].Id = i + 1;
			}

			builder.HasData(types);
		}

		public static void Seed(this EntityTypeBuilder<SideDish> builder)
		{
			var names = new[] {
				"Brambory", // 1
				"Bramborová kaše", // 2
				"Knedlíky", // 3
				"Rýže", // 4
				"Těstoviny", // 5
				"Hranolky", // 6
				"Pečivo", // 7
				"Zelenina" // 8
			};

			var sides = names.Select((x, index) => new SideDish {
				Id = index + 1,
				Name = x,
				Description = "",
			});

			builder.HasData(sides);
		}

		public static void Seed(this EntityTypeBuilder<Food> builder)
		{
			var foods = FoodNames.Select((x, index) => new Food {
				Id = index + 1,
				Name = x.Name,
				TypeId = x.Type,
				GlutenFree = true,
			});

			builder.HasData(foods);
		}

		public static void Seed(this EntityTypeBuilder<FoodSide> builder)
		{
			var foods = FoodNames.SelectMany((x, index) =>
												 x.FoodSides
												  .Select(y =>
															  new FoodSide {
																  FoodId = index + 1,
																  SideId = y
															  }));

			builder.HasData(foods);
		}

		public static void Seed(this EntityTypeBuilder<FoodCategory> builder)
		{
			var foods = FoodNames.SelectMany((x, index) =>
												 x.Categories
												  .Select(y =>
															  new FoodCategory {
																  FoodId = index + 1,
																  CategoryId = y
															  }));

			builder.HasData(foods);
		}
	}
}