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
			new FoodName(1, 2) {Name = "Kotlety na cibulce", Type = 1, Category = 3,},
			new FoodName(1) {Name = "Ražniči", Type = 1, Category = 3,},
			new FoodName(1, 6) {Name = "Naložené kuřecí plátky", Type = 1, Category = 3,},
			new FoodName(1, 6) {Name = "Naložené vepřové plátky", Type = 1, Category = 3,},
			new FoodName(3) {Name = "Knedlo, vepřo, zelo", Type = 1, Category = 3,},
			new FoodName(3) {Name = "Knedlo, vepřo, špenát", Type = 1, Category = 3,},
			new FoodName(1) {Name = "Špenát s vajíčkem", Type = 1, Category = 2,},
			new FoodName(1, 2, 6) {Name = "Řízky", Type = 1, Category = 3,},
			new FoodName(1, 2) {Name = "Filé", Type = 1, Category = 3,},
			new FoodName(1, 2) {Name = "Sekaná", Type = 1, Category = 3,},
			new FoodName() {Name = "Rizoto kuřecí", Type = 1, Category = 3,},
			new FoodName() {Name = "Rizoto vepřové", Type = 1, Category = 3,},
			new FoodName(1, 3) {Name = "Kuře na papirce", Type = 1, Category = 3,},
			new FoodName(1, 3) {Name = "Rajská", Type = 1, Category = 3,},
			new FoodName(1, 5) {Name = "Guláš", Type = 1, Category = 3,},
			new FoodName(1) {Name = "Buřt guláš", Type = 1, Category = 3,},
			new FoodName(1, 2, 4) {Name = "Ptáčky", Type = 1, Category = 3,},
			new FoodName(1) {Name = "Houbová omáčka", Type = 1, Category = 3,},
			new FoodName(1, 3) {Name = "Koprovka", Type = 1, Category = 2,},
			new FoodName() {Name = "Šunkafleky", Type = 1, Category = 3,},
			new FoodName() {Name = "Zapečné brambory", Type = 1, Category = 3,},
			new FoodName(1, 6) {Name = "Maso ve smetanové omáčce", Type = 1, Category = 3,},
			new FoodName(1, 6) {Name = "Maso zapečené s kečupem", Type = 1, Category = 3,},
			new FoodName(1) {Name = "Kuře s nádivkou", Type = 1, Category = 3,},
			new FoodName(1, 2, 7, 8) {Name = "Klobása", Type = 1, Category = 3,},
			new FoodName(1, 2, 6) {Name = "Kuřecí kapsa", Type = 1, Category = 3,},
			new FoodName(1, 6) {Name = "Smažený sýr", Type = 1, Category = 3,},
			new FoodName(1, 6) {Name = "Žampiony", Type = 1, Category = 2,},
			new FoodName(1, 6) {Name = "Květák", Type = 1, Category = 2,},
			new FoodName(1, 2) {Name = "Holandký řízek", Type = 1, Category = 3,},
			new FoodName() {Name = "Halušky", Type = 1, Category = 3,},
			new FoodName() {Name = "Špagety", Type = 1, Category = 3,},
			new FoodName() {Name = "Těstoviny stuňákem", Type = 1, Category = 3,},
			new FoodName() {Name = "Bramboráky", Type = 1, Category = 2,},
			new FoodName(1, 2, 4, 6) {Name = "Roláda kuřecí", Type = 1, Category = 3,},
			new FoodName(1, 2, 4, 6) {Name = "Roláda vepřová", Type = 1, Category = 3,},
			new FoodName(1) {Name = "Dušení mrkev + maso", Type = 1, Category = 3,},
			new FoodName() {Name = "Čína", Type = 1, Category = 3,},
			new FoodName(1, 2) {Name = "Karbanátky", Type = 1, Category = 3,},
			new FoodName(1, 2) {Name = "Čevabčiči", Type = 1, Category = 3,},
			new FoodName(1, 2, 4, 6) {Name = "Kuřecí plátek v alobalu", Type = 1, Category = 3,},
			new FoodName(1, 2, 6) {Name = "Johančino tajemství", Type = 1, Category = 3,},
			new FoodName(7) {Name = "Čočka na kyselo", Type = 1, Category = 3,},
			new FoodName(1, 7) {Name = "Míchaná zelenina", Type = 1, Category = 2,},
		};

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

		public static void Seed(this EntityTypeBuilder<FoodType> builder)
		{
			var types = new[] {
				new FoodType {
					Id = 1,
					Name = "Hlavní jídlo",
					Description = "",
				},
				new FoodType {
					Id = 2,
					Name = "Polévka",
					Description = "",
				},
				new FoodType {
					Id = 3,
					Name = "Zákusek",
					Description = "",
				}
			};

			builder.HasData(types);
		}

		public static void Seed(this EntityTypeBuilder<FoodCategory> builder)
		{
			var types = new[] {
				new FoodCategory {
					Id = 1,
					Name = "Sladké",
					Description = "",
				},
				new FoodCategory {
					Id = 2,
					Name = "Bezmasé",
					Description = "",
				},
				new FoodCategory {
					Id = 3,
					Name = "S masem",
					Description = "",
				}
			};

			builder.HasData(types);
		}

		public static void Seed(this EntityTypeBuilder<Food> builder)
		{
			var foods = FoodNames.Select((x, index) => new Food {
				Id = index + 1,
				Name = x.Name,
				TypeId = x.Type,
				CategoryId = x.Category,
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
	}
}