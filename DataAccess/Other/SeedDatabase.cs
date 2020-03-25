using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Other
{
	public static class SeedDatabase
	{
		public static void Seed(this EntityTypeBuilder<FoodType> builder)
		{
			var types = new[] {
				new FoodType {
					Id = 60,
					Name = "Hlavní jídlo",
					Description = "",
				},
				new FoodType {
					Id = 70,
					Name = "Polévka",
					Description = "",
				},
				new FoodType {
					Id = 80,
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
			var names = new[] {
				new {Name = "Kotlety na cibulce", Type = 1, Category = 3,},
				new {Name = "Ražniči", Type = 1, Category = 3,},
				new {Name = "Naložené kuřecí plátky", Type = 1, Category = 3,},
				new {Name = "Naložené vepřové plátky", Type = 1, Category = 3,},
				new {Name = "Knedlo, vepřo, zelo", Type = 1, Category = 3,},
				new {Name = "Knedlo, vepřo, špenát", Type = 1, Category = 3,},
				new {Name = "Špeán s vajíčkem", Type = 1, Category = 2,},
				new {Name = "Řízky", Type = 1, Category = 3,},
				new {Name = "Filé", Type = 1, Category = 3,},
				new {Name = "Sekaná", Type = 1, Category = 3,},
				new {Name = "Rizoto kuřecí", Type = 1, Category = 3,},
				new {Name = "Rizoto vepřové", Type = 1, Category = 3,},
				new {Name = "Kuře na papirce", Type = 1, Category = 3,},
				new {Name = "Rajská", Type = 1, Category = 3,},
				new {Name = "Guláš", Type = 1, Category = 3,},
				new {Name = "Bučt guláš", Type = 1, Category = 3,},
				new {Name = "Ptáčky", Type = 1, Category = 3,},
				new {Name = "Houbová omáčka", Type = 1, Category = 3,},
				new {Name = "Koprovka", Type = 1, Category = 2,},
				new {Name = "Šunkafleky", Type = 1, Category = 3,},
				new {Name = "Zapečné brambory", Type = 1, Category = 3,},
				new {Name = "Maso ve smetanové omáčce", Type = 1, Category = 3,},
				new {Name = "Maso zapečené s kečupem", Type = 1, Category = 3,},
				new {Name = "Kuře s nádivkou", Type = 1, Category = 3,},
				new {Name = "Klobása", Type = 1, Category = 3,},
				new {Name = "Kuřecí kapsa", Type = 1, Category = 3,},
				new {Name = "Smažený sýr", Type = 1, Category = 3,},
				new {Name = "Žampiony", Type = 1, Category = 2,},
				new {Name = "Květák", Type = 1, Category = 2,},
				new {Name = "Holandký řízek", Type = 1, Category = 3,},
				new {Name = "Halušky", Type = 1, Category = 3,},
				new {Name = "Špagety", Type = 1, Category = 3,},
				new {Name = "Těstoviny stuňákem", Type = 1, Category = 3,},
				new {Name = "Bramboráky", Type = 1, Category = 2,},
				new {Name = "Roláda kuřecí", Type = 1, Category = 3,},
				new {Name = "Roláda vepřová", Type = 1, Category = 3,},
				new {Name = "Dušení mrkev + maso", Type = 1, Category = 3,},
				new {Name = "Čína", Type = 1, Category = 3,},
				new {Name = "Karbanátky", Type = 1, Category = 3,},
				new {Name = "Čevabčiči", Type = 1, Category = 3,},
				new {Name = "Kuřecí plátek v alobalu", Type = 1, Category = 3,},
				new {Name = "Johančino tajemství", Type = 1, Category = 3,},
				new {Name = "Čočka na kyselo", Type = 1, Category = 3,},
				new {Name = "Míchaná zelenina", Type = 1, Category = 2,},
			};
			builder.HasData(names.Select((x, index) => new Food {
				Id = index + 1,
				Name = x.Name,
				TypeId = x.Type,
				CategoryId = x.Category,
			}));
		}
	}
}