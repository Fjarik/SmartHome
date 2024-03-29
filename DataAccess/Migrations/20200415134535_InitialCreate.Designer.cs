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
    [Migration("20200415134535_InitialCreate")]
    partial class InitialCreate
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

                    b.ToTable("Foods");
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

            modelBuilder.Entity("DataAccess.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("FoodId")
                        .HasColumnName("FoodID")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int?>("OriginalMealId")
                        .HasColumnName("OriginalMealID")
                        .HasColumnType("int");

                    b.Property<int?>("SideId")
                        .HasColumnName("SideID")
                        .HasColumnType("int");

                    b.Property<int?>("SoupId")
                        .HasColumnName("SoupID")
                        .HasColumnType("int");

                    b.Property<short>("TimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TimeID")
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("((2))")
                        .HasComment("Snídaně, oběd, večeře");

                    b.Property<short>("TypeId")
                        .HasColumnName("TypeID")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("OriginalMealId");

                    b.HasIndex("SideId");

                    b.HasIndex("SoupId");

                    b.ToTable("Meals");

                    b.HasComment("Jídla v jednotlivé dny");
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
                        .WithMany("FoodSideFoods")
                        .HasForeignKey("FoodId")
                        .HasConstraintName("FK_FoodSides_Foods")
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Food", "Side")
                        .WithMany("FoodSideSides")
                        .HasForeignKey("SideId")
                        .HasConstraintName("FK_FoodSides_Side")
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Models.Meal", b =>
                {
                    b.HasOne("DataAccess.Models.Food", "Food")
                        .WithMany("MealFoods")
                        .HasForeignKey("FoodId")
                        .HasConstraintName("FK_Meals_Foods");

                    b.HasOne("DataAccess.Models.Meal", "OriginalMeal")
                        .WithMany("InverseOriginalMeal")
                        .HasForeignKey("OriginalMealId")
                        .HasConstraintName("FK_Meals_OriginalMeals");

                    b.HasOne("DataAccess.Models.Food", "Side")
                        .WithMany("MealSides")
                        .HasForeignKey("SideId")
                        .HasConstraintName("FK_Meals_SideDish");

                    b.HasOne("DataAccess.Models.Food", "Soup")
                        .WithMany("MealSoups")
                        .HasForeignKey("SoupId")
                        .HasConstraintName("FK_Meals_Soup");
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
