﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    IsHealthy = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                },
                comment: "Smažené, dušení, s masem, bez masa");

            migrationBuilder.CreateTable(
                name: "FoodTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypes", x => x.ID);
                },
                comment: "Polévka, hlavní jídla...");

            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.ID);
                },
                comment: "Hlavní jídlo, krabička, ...");

            migrationBuilder.CreateTable(
                name: "SideDishes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    GlutenFree = table.Column<bool>(nullable: false, defaultValueSql: "((1))", comment: "Bez lepku")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideDishes", x => x.ID);
                },
                comment: "Přilohy");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoogleID = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                },
                comment: "");

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeID = table.Column<int>(nullable: false, comment: "Hlavní jídlo, polévka..."),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    GlutenFree = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Foods_FoodTypes",
                        column: x => x.TypeID,
                        principalTable: "FoodTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    TokenString = table.Column<string>(maxLength: 500, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Expiration = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tokens_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    FoodID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories_1", x => new { x.FoodID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_FoodCategories_Categories",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodCategories_Foods",
                        column: x => x.FoodID,
                        principalTable: "Foods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "");

            migrationBuilder.CreateTable(
                name: "FoodSides",
                columns: table => new
                {
                    FoodID = table.Column<int>(nullable: false),
                    SideID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodSides", x => new { x.FoodID, x.SideID });
                    table.ForeignKey(
                        name: "FK_FoodSides_Foods",
                        column: x => x.FoodID,
                        principalTable: "Foods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodSides_SideDishes",
                        column: x => x.SideID,
                        principalTable: "SideDishes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Defaultní přílohy k jídlům");

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CookedByID = table.Column<int>(nullable: false),
                    FoodID = table.Column<int>(nullable: false),
                    TypeID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Meals_Users",
                        column: x => x.CookedByID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meals_Foods",
                        column: x => x.FoodID,
                        principalTable: "Foods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meals_MealTypes",
                        column: x => x.TypeID,
                        principalTable: "MealTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealCategories",
                columns: table => new
                {
                    MealID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealCategories_1", x => new { x.MealID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_MealCategories_Categories",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealCategories_Meals",
                        column: x => x.MealID,
                        principalTable: "Meals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "");

            migrationBuilder.CreateTable(
                name: "MealSides",
                columns: table => new
                {
                    MealID = table.Column<int>(nullable: false),
                    SideDishesID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealSides", x => new { x.MealID, x.SideDishesID });
                    table.ForeignKey(
                        name: "FK_MealSides_Meals",
                        column: x => x.MealID,
                        principalTable: "Meals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealSides_SideDishes",
                        column: x => x.SideDishesID,
                        principalTable: "SideDishes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UK_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_CategoryID",
                table: "FoodCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "UK_Foods_Name",
                table: "Foods",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_TypeID",
                table: "Foods",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSides_SideID",
                table: "FoodSides",
                column: "SideID");

            migrationBuilder.CreateIndex(
                name: "UK_FoodTypes_Name",
                table: "FoodTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealCategories_CategoryID",
                table: "MealCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CookedByID",
                table: "Meals",
                column: "CookedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_FoodID",
                table: "Meals",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_TypeID",
                table: "Meals",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MealSides_SideDishesID",
                table: "MealSides",
                column: "SideDishesID");

            migrationBuilder.CreateIndex(
                name: "UK_MealTypes_Name",
                table: "MealTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_SideDishes_Name",
                table: "SideDishes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserID",
                table: "Tokens",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "UK_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Users_Google",
                table: "Users",
                column: "GoogleID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodCategories");

            migrationBuilder.DropTable(
                name: "FoodSides");

            migrationBuilder.DropTable(
                name: "MealCategories");

            migrationBuilder.DropTable(
                name: "MealSides");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "SideDishes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropTable(
                name: "FoodTypes");
        }
    }
}
