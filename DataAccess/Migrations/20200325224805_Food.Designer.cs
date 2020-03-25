﻿// <auto-generated />
using System;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20200325224805_Food")]
    partial class Food
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool?>("IsHealthy")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UK_Categories_Name");

                    b.ToTable("Categories");

                    b.HasComment("Smažené, dušení, s masem, bez masa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Všechna sladká jídla",
                            IsHealthy = false,
                            Name = "Sladké"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Jídla, která neobsahují maso",
                            IsHealthy = true,
                            Name = "Bezmasé"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Jídla s libovolným obsahem jakéhokoliv masa",
                            Name = "S masem"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Jídla, která byla upravena procesem smažením",
                            IsHealthy = false,
                            Name = "Smažené"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Jídla, která byla upravena procesem upečením",
                            Name = "Pečené"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Jídla, která byla upravena procesem vařením",
                            Name = "Vařené"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Jídla, která byla upravena procesem grilováním",
                            IsHealthy = false,
                            Name = "Grilované"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Jídla, která byla upravena procesem dušením",
                            IsHealthy = true,
                            Name = "Dušené"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Jídla, která jsou servírována s omáčkou",
                            Name = "S omáčkou"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Jídla, která jsou servírována se sosem",
                            Name = "Se sosem"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("GlutenFree")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("TypeId")
                        .HasColumnName("TypeID")
                        .HasColumnType("int")
                        .HasComment("Hlavní jídlo, polévka...");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UK_Foods_Name");

                    b.HasIndex("TypeId");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GlutenFree = true,
                            Name = "Kotlety na cibulce",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            GlutenFree = true,
                            Name = "Ražniči",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            GlutenFree = true,
                            Name = "Naložené kuřecí plátky",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            GlutenFree = true,
                            Name = "Naložené vepřové plátky",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 5,
                            GlutenFree = true,
                            Name = "Knedlo, vepřo, zelo",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 6,
                            GlutenFree = true,
                            Name = "Knedlo, vepřo, špenát",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 7,
                            GlutenFree = true,
                            Name = "Špenát s vajíčkem",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 8,
                            GlutenFree = true,
                            Name = "Řízky",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 9,
                            GlutenFree = true,
                            Name = "Filé",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 10,
                            GlutenFree = true,
                            Name = "Sekaná",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 11,
                            GlutenFree = true,
                            Name = "Rizoto kuřecí",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 12,
                            GlutenFree = true,
                            Name = "Rizoto vepřové",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 13,
                            GlutenFree = true,
                            Name = "Kuře na papirce",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 14,
                            GlutenFree = true,
                            Name = "Rajská",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 15,
                            GlutenFree = true,
                            Name = "Guláš",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 16,
                            GlutenFree = true,
                            Name = "Buřt guláš",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 17,
                            GlutenFree = true,
                            Name = "Ptáčky",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 18,
                            GlutenFree = true,
                            Name = "Houbová omáčka",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 19,
                            GlutenFree = true,
                            Name = "Koprovka",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 20,
                            GlutenFree = true,
                            Name = "Šunkafleky",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 21,
                            GlutenFree = true,
                            Name = "Zapečné brambory",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 22,
                            GlutenFree = true,
                            Name = "Maso ve smetanové omáčce",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 23,
                            GlutenFree = true,
                            Name = "Maso zapečené s kečupem",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 24,
                            GlutenFree = true,
                            Name = "Kuře s nádivkou",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 25,
                            GlutenFree = true,
                            Name = "Klobása",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 26,
                            GlutenFree = true,
                            Name = "Kuřecí kapsa",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 27,
                            GlutenFree = true,
                            Name = "Smažený sýr",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 28,
                            GlutenFree = true,
                            Name = "Žampiony",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 29,
                            GlutenFree = true,
                            Name = "Květák",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 30,
                            GlutenFree = true,
                            Name = "Holandký řízek",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 31,
                            GlutenFree = true,
                            Name = "Halušky",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 32,
                            GlutenFree = true,
                            Name = "Špagety",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 33,
                            GlutenFree = true,
                            Name = "Těstoviny stuňákem",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 34,
                            GlutenFree = true,
                            Name = "Bramboráky",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 35,
                            GlutenFree = true,
                            Name = "Roláda kuřecí",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 36,
                            GlutenFree = true,
                            Name = "Roláda vepřová",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 37,
                            GlutenFree = true,
                            Name = "Dušení mrkev + maso",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 38,
                            GlutenFree = true,
                            Name = "Čína",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 39,
                            GlutenFree = true,
                            Name = "Karbanátky",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 40,
                            GlutenFree = true,
                            Name = "Čevabčiči",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 41,
                            GlutenFree = true,
                            Name = "Kuřecí plátek v alobalu",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 42,
                            GlutenFree = true,
                            Name = "Johančino tajemství",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 43,
                            GlutenFree = true,
                            Name = "Čočka na kyselo",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 44,
                            GlutenFree = true,
                            Name = "Míchaná zelenina",
                            TypeId = 1
                        });
                });

            modelBuilder.Entity("DataAccess.Models.FoodCategory", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnName("FoodID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("FoodId", "CategoryId")
                        .HasName("PK_FoodCategories_1");

                    b.HasIndex("CategoryId");

                    b.ToTable("FoodCategories");

                    b.HasComment("");
                });

            modelBuilder.Entity("DataAccess.Models.FoodSide", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnName("FoodID")
                        .HasColumnType("int");

                    b.Property<int>("SideId")
                        .HasColumnName("SideID")
                        .HasColumnType("int");

                    b.HasKey("FoodId", "SideId");

                    b.HasIndex("SideId");

                    b.ToTable("FoodSides");

                    b.HasComment("Defaultní přílohy k jídlům");
                });

            modelBuilder.Entity("DataAccess.Models.FoodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UK_FoodTypes_Name");

                    b.ToTable("FoodTypes");

                    b.HasComment("Polévka, hlavní jídla...");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            Name = "Hlavní jídlo"
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Name = "Polévka"
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            Name = "Zákusek"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CookedById")
                        .HasColumnName("CookedByID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("FoodId")
                        .HasColumnName("FoodID")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnName("TypeID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CookedById");

                    b.HasIndex("FoodId");

                    b.HasIndex("TypeId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("DataAccess.Models.MealCategory", b =>
                {
                    b.Property<int>("MealId")
                        .HasColumnName("MealID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("MealId", "CategoryId")
                        .HasName("PK_MealCategories_1");

                    b.HasIndex("CategoryId");

                    b.ToTable("MealCategories");

                    b.HasComment("");
                });

            modelBuilder.Entity("DataAccess.Models.MealSide", b =>
                {
                    b.Property<int>("MealId")
                        .HasColumnName("MealID")
                        .HasColumnType("int");

                    b.Property<int>("SideDishesId")
                        .HasColumnName("SideDishesID")
                        .HasColumnType("int");

                    b.HasKey("MealId", "SideDishesId");

                    b.HasIndex("SideDishesId");

                    b.ToTable("MealSides");
                });

            modelBuilder.Entity("DataAccess.Models.MealType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UK_MealTypes_Name");

                    b.ToTable("MealTypes");

                    b.HasComment("Hlavní jídlo, krabička, ...");
                });

            modelBuilder.Entity("DataAccess.Models.SideDish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool?>("GlutenFree")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))")
                        .HasComment("Bez lepku");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UK_SideDishes_Name");

                    b.ToTable("SideDishes");

                    b.HasComment("Přilohy");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            Name = "Brambory"
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Name = "Bramborová kaše"
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            Name = "Knedlíky"
                        },
                        new
                        {
                            Id = 4,
                            Description = "",
                            Name = "Rýže"
                        },
                        new
                        {
                            Id = 5,
                            Description = "",
                            Name = "Těstoviny"
                        },
                        new
                        {
                            Id = 6,
                            Description = "",
                            Name = "Hranolky"
                        },
                        new
                        {
                            Id = 7,
                            Description = "",
                            Name = "Pečivo"
                        },
                        new
                        {
                            Id = 8,
                            Description = "",
                            Name = "Zelenina"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime");

                    b.Property<string>("TokenString")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("UserId")
                        .HasColumnName("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("DataAccess.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("GoogleId")
                        .IsRequired()
                        .HasColumnName("GoogleID")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UK_Users_Email");

                    b.HasIndex("GoogleId")
                        .IsUnique()
                        .HasName("UK_Users_Google");

                    b.ToTable("Users");

                    b.HasComment("");
                });

            modelBuilder.Entity("DataAccess.Models.Food", b =>
                {
                    b.HasOne("DataAccess.Models.FoodType", "Type")
                        .WithMany("Foods")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Foods_FoodTypes")
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Models.FoodCategory", b =>
                {
                    b.HasOne("DataAccess.Models.Category", "Category")
                        .WithMany("FoodCategories")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_FoodCategories_Categories")
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Food", "Food")
                        .WithMany("FoodCategories")
                        .HasForeignKey("FoodId")
                        .HasConstraintName("FK_FoodCategories_Foods")
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Models.FoodSide", b =>
                {
                    b.HasOne("DataAccess.Models.Food", "Food")
                        .WithMany("FoodSides")
                        .HasForeignKey("FoodId")
                        .HasConstraintName("FK_FoodSides_Foods")
                        .IsRequired();

                    b.HasOne("DataAccess.Models.SideDish", "Side")
                        .WithMany("FoodSides")
                        .HasForeignKey("SideId")
                        .HasConstraintName("FK_FoodSides_SideDishes")
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Models.Meal", b =>
                {
                    b.HasOne("DataAccess.Models.User", "CookedBy")
                        .WithMany("Meals")
                        .HasForeignKey("CookedById")
                        .HasConstraintName("FK_Meals_Users")
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Food", "Food")
                        .WithMany("Meals")
                        .HasForeignKey("FoodId")
                        .HasConstraintName("FK_Meals_Foods")
                        .IsRequired();

                    b.HasOne("DataAccess.Models.MealType", "Type")
                        .WithMany("Meals")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Meals_MealTypes")
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Models.MealCategory", b =>
                {
                    b.HasOne("DataAccess.Models.Category", "Category")
                        .WithMany("MealCategories")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_MealCategories_Categories")
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Meal", "Meal")
                        .WithMany("MealCategories")
                        .HasForeignKey("MealId")
                        .HasConstraintName("FK_MealCategories_Meals")
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Models.MealSide", b =>
                {
                    b.HasOne("DataAccess.Models.Meal", "Meal")
                        .WithMany("MealSides")
                        .HasForeignKey("MealId")
                        .HasConstraintName("FK_MealSides_Meals")
                        .IsRequired();

                    b.HasOne("DataAccess.Models.SideDish", "SideDishes")
                        .WithMany("MealSides")
                        .HasForeignKey("SideDishesId")
                        .HasConstraintName("FK_MealSides_SideDishes")
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Models.Token", b =>
                {
                    b.HasOne("DataAccess.Models.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Tokens_Users")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
