using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SeedOther : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodCategories",
                columns: new[] { "FoodID", "CategoryID" },
                values: new object[,]
                {
                    { 9, 3 },
                    { 44, 3 },
                    { 43, 5 },
                    { 43, 3 },
                    { 42, 4 },
                    { 42, 2 },
                    { 41, 6 },
                    { 41, 3 },
                    { 40, 3 },
                    { 39, 5 },
                    { 39, 3 },
                    { 38, 5 },
                    { 38, 3 },
                    { 37, 4 },
                    { 37, 2 },
                    { 36, 5 },
                    { 36, 4 },
                    { 36, 2 },
                    { 35, 4 },
                    { 35, 3 },
                    { 34, 5 },
                    { 34, 3 },
                    { 33, 7 },
                    { 33, 5 },
                    { 44, 5 },
                    { 33, 3 },
                    { 45, 3 },
                    { 45, 8 },
                    { 60, 2 },
                    { 59, 3 },
                    { 58, 2 },
                    { 57, 2 },
                    { 56, 2 },
                    { 55, 2 },
                    { 54, 3 },
                    { 53, 5 },
                    { 53, 3 },
                    { 52, 5 },
                    { 52, 2 },
                    { 51, 6 },
                    { 51, 3 },
                    { 50, 5 },
                    { 50, 3 },
                    { 49, 5 },
                    { 49, 3 },
                    { 48, 5 },
                    { 48, 3 },
                    { 47, 5 },
                    { 47, 3 },
                    { 46, 5 },
                    { 46, 3 },
                    { 45, 5 },
                    { 32, 5 },
                    { 40, 6 },
                    { 31, 5 },
                    { 20, 5 },
                    { 20, 3 },
                    { 19, 5 },
                    { 19, 3 },
                    { 18, 5 },
                    { 18, 3 },
                    { 17, 5 },
                    { 17, 3 },
                    { 16, 4 },
                    { 16, 3 },
                    { 15, 5 },
                    { 15, 2 },
                    { 14, 5 },
                    { 14, 3 },
                    { 13, 5 },
                    { 32, 3 },
                    { 12, 5 },
                    { 12, 3 },
                    { 11, 5 },
                    { 11, 3 },
                    { 10, 5 },
                    { 10, 3 },
                    { 9, 5 },
                    { 21, 3 },
                    { 21, 5 },
                    { 13, 3 },
                    { 22, 3 },
                    { 21, 9 },
                    { 31, 3 },
                    { 30, 9 },
                    { 30, 5 },
                    { 30, 3 },
                    { 29, 3 },
                    { 28, 5 },
                    { 28, 3 },
                    { 27, 6 },
                    { 27, 2 },
                    { 26, 9 },
                    { 26, 6 },
                    { 29, 5 },
                    { 25, 5 },
                    { 26, 3 },
                    { 22, 9 },
                    { 23, 3 },
                    { 22, 5 },
                    { 23, 9 },
                    { 23, 6 },
                    { 24, 3 },
                    { 24, 6 },
                    { 24, 9 },
                    { 25, 3 }
                });

            migrationBuilder.InsertData(
                table: "FoodSides",
                columns: new[] { "FoodID", "SideID" },
                values: new object[,]
                {
                    { 44, 1 },
                    { 43, 4 },
                    { 43, 2 },
                    { 43, 1 },
                    { 38, 2 },
                    { 43, 6 },
                    { 38, 1 },
                    { 35, 6 },
                    { 37, 1 },
                    { 36, 6 },
                    { 36, 1 },
                    { 35, 1 },
                    { 34, 6 },
                    { 44, 2 },
                    { 34, 2 },
                    { 37, 6 },
                    { 44, 4 },
                    { 50, 6 },
                    { 45, 1 },
                    { 34, 1 },
                    { 53, 7 },
                    { 53, 1 },
                    { 52, 7 },
                    { 52, 1 },
                    { 51, 7 },
                    { 50, 2 },
                    { 44, 6 },
                    { 50, 1 },
                    { 49, 4 },
                    { 49, 2 },
                    { 49, 1 },
                    { 48, 2 },
                    { 48, 1 },
                    { 47, 2 },
                    { 47, 1 },
                    { 49, 6 },
                    { 33, 8 },
                    { 17, 2 },
                    { 33, 2 },
                    { 18, 1 },
                    { 33, 7 },
                    { 16, 6 },
                    { 16, 2 },
                    { 16, 1 },
                    { 15, 1 },
                    { 14, 3 },
                    { 13, 3 },
                    { 12, 6 },
                    { 12, 1 },
                    { 11, 6 },
                    { 11, 1 },
                    { 10, 1 },
                    { 9, 2 },
                    { 9, 1 },
                    { 18, 2 },
                    { 21, 1 },
                    { 17, 1 },
                    { 22, 1 },
                    { 33, 1 },
                    { 32, 1 },
                    { 31, 6 },
                    { 21, 3 },
                    { 30, 6 },
                    { 30, 1 },
                    { 27, 3 },
                    { 27, 1 },
                    { 31, 1 },
                    { 25, 4 },
                    { 25, 2 },
                    { 25, 1 },
                    { 24, 1 },
                    { 26, 1 },
                    { 23, 5 },
                    { 23, 1 },
                    { 22, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 1,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 2,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 3,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 4,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 5,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 6,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 7,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 8,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 9,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 10,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 11,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 12,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 13,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 14,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 15,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 16,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 17,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 18,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 19,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 20,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 21,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 22,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 23,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 24,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 25,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 26,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 27,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 28,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 29,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 30,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 31,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 32,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 33,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 34,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 35,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 36,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 37,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 38,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 39,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 40,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 41,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 42,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 43,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 44,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 45,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 46,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 47,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 48,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 49,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 50,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 51,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 52,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 53,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 54,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 55,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 56,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 57,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 58,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 59,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 60,
                column: "GlutenFree",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 15, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 16, 4 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 17, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 17, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 18, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 18, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 19, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 19, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 20, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 20, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 21, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 21, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 21, 9 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 22, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 22, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 22, 9 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 23, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 23, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 23, 9 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 24, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 24, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 24, 9 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 25, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 25, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 26, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 26, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 26, 9 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 27, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 27, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 28, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 28, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 29, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 29, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 30, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 30, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 30, 9 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 31, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 31, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 32, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 32, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 33, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 33, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 33, 7 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 34, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 34, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 35, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 35, 4 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 36, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 36, 4 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 36, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 37, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 37, 4 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 38, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 38, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 39, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 39, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 40, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 40, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 41, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 41, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 42, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 42, 4 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 43, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 43, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 44, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 44, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 45, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 45, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 45, 8 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 46, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 46, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 47, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 47, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 48, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 48, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 49, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 49, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 50, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 50, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 51, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 51, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 52, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 52, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 53, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 53, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 54, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 55, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 56, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 57, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 58, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 59, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 60, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 16, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 21, 3 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 22, 3 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 23, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 23, 5 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 24, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 25, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 25, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 25, 4 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 26, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 27, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 27, 3 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 30, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 30, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 31, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 31, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 32, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 33, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 33, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 33, 7 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 33, 8 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 34, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 34, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 34, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 35, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 35, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 36, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 36, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 37, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 37, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 38, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 38, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 43, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 43, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 43, 4 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 43, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 44, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 44, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 44, 4 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 44, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 45, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 47, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 47, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 48, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 48, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 49, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 49, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 49, 4 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 49, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 50, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 50, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 50, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 51, 7 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 52, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 52, 7 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 53, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 53, 7 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 1,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 2,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 3,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 4,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 5,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 6,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 7,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 8,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 9,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 10,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 11,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 12,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 13,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 14,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 15,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 16,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 17,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 18,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 19,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 20,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 21,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 22,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 23,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 24,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 25,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 26,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 27,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 28,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 29,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 30,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 31,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 32,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 33,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 34,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 35,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 36,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 37,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 38,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 39,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 40,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 41,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 42,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 43,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 44,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 45,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 46,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 47,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 48,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 49,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 50,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 51,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 52,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 53,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 54,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 55,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 56,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 57,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 58,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 59,
                column: "GlutenFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 60,
                column: "GlutenFree",
                value: true);
        }
    }
}
