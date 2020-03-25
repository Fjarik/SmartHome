using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FoodRelated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodCategories",
                columns: new[] { "FoodID", "CategoryID" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 32, 6 },
                    { 32, 3 },
                    { 31, 5 },
                    { 31, 3 },
                    { 30, 5 },
                    { 29, 4 },
                    { 29, 2 },
                    { 28, 5 },
                    { 28, 4 },
                    { 33, 3 },
                    { 28, 2 },
                    { 27, 3 },
                    { 26, 5 },
                    { 26, 3 },
                    { 25, 7 },
                    { 25, 5 },
                    { 25, 3 },
                    { 24, 5 },
                    { 24, 3 },
                    { 23, 5 },
                    { 27, 4 },
                    { 33, 6 },
                    { 34, 2 },
                    { 34, 4 },
                    { 44, 5 },
                    { 44, 2 },
                    { 43, 6 },
                    { 43, 3 },
                    { 42, 5 },
                    { 42, 3 },
                    { 41, 5 },
                    { 41, 3 },
                    { 40, 5 },
                    { 40, 3 },
                    { 39, 5 },
                    { 39, 3 },
                    { 38, 5 },
                    { 38, 3 },
                    { 37, 8 },
                    { 37, 5 },
                    { 37, 3 },
                    { 36, 5 },
                    { 36, 3 },
                    { 35, 5 },
                    { 35, 3 },
                    { 23, 3 },
                    { 22, 9 },
                    { 30, 3 },
                    { 22, 3 },
                    { 11, 5 },
                    { 11, 3 },
                    { 10, 5 },
                    { 10, 3 },
                    { 9, 5 },
                    { 9, 3 },
                    { 8, 4 },
                    { 8, 3 },
                    { 7, 5 },
                    { 7, 2 },
                    { 6, 5 },
                    { 6, 3 },
                    { 5, 5 },
                    { 5, 3 },
                    { 22, 5 },
                    { 4, 3 },
                    { 3, 5 },
                    { 3, 3 },
                    { 2, 5 },
                    { 2, 3 },
                    { 1, 5 },
                    { 12, 3 },
                    { 12, 5 },
                    { 4, 5 },
                    { 13, 5 },
                    { 13, 3 },
                    { 21, 5 },
                    { 21, 3 },
                    { 20, 5 },
                    { 19, 6 },
                    { 19, 2 },
                    { 18, 9 },
                    { 18, 6 },
                    { 18, 3 },
                    { 17, 5 },
                    { 17, 3 },
                    { 20, 3 },
                    { 16, 6 },
                    { 16, 9 },
                    { 14, 3 },
                    { 14, 9 },
                    { 15, 3 },
                    { 14, 5 },
                    { 15, 6 },
                    { 15, 9 },
                    { 16, 3 },
                    { 13, 9 }
                });

            migrationBuilder.InsertData(
                table: "FoodSides",
                columns: new[] { "FoodID", "SideID" },
                values: new object[,]
                {
                    { 35, 4 },
                    { 29, 6 },
                    { 35, 2 },
                    { 35, 1 },
                    { 30, 2 },
                    { 30, 1 },
                    { 35, 6 },
                    { 27, 6 },
                    { 28, 6 },
                    { 28, 1 },
                    { 27, 1 },
                    { 26, 6 },
                    { 26, 2 },
                    { 36, 1 },
                    { 26, 1 },
                    { 29, 1 },
                    { 36, 2 },
                    { 41, 6 },
                    { 36, 6 },
                    { 25, 8 },
                    { 44, 7 },
                    { 44, 1 },
                    { 43, 7 },
                    { 42, 6 },
                    { 42, 2 },
                    { 42, 1 },
                    { 41, 4 },
                    { 41, 2 },
                    { 41, 1 },
                    { 40, 2 },
                    { 40, 1 },
                    { 39, 2 },
                    { 39, 1 },
                    { 37, 1 },
                    { 36, 4 },
                    { 25, 7 },
                    { 7, 1 },
                    { 25, 1 },
                    { 9, 2 },
                    { 9, 1 },
                    { 8, 6 },
                    { 8, 2 },
                    { 8, 1 },
                    { 25, 2 },
                    { 6, 3 },
                    { 5, 3 },
                    { 4, 6 },
                    { 4, 1 },
                    { 3, 6 },
                    { 3, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 1, 1 },
                    { 10, 1 },
                    { 13, 1 },
                    { 10, 2 },
                    { 18, 1 },
                    { 23, 6 },
                    { 23, 1 },
                    { 22, 6 },
                    { 22, 1 },
                    { 19, 3 },
                    { 19, 1 },
                    { 13, 3 },
                    { 17, 4 },
                    { 17, 2 },
                    { 17, 1 },
                    { 16, 1 },
                    { 15, 5 },
                    { 15, 1 },
                    { 14, 3 },
                    { 14, 1 },
                    { 24, 1 }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 8, 4 });

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
                keyValues: new object[] { 13, 9 });

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
                keyValues: new object[] { 14, 9 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 15, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 15, 9 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 16, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 16, 9 });

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
                keyValues: new object[] { 18, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 18, 9 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 19, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 19, 6 });

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
                keyValues: new object[] { 23, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 24, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 24, 5 });

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
                keyValues: new object[] { 25, 7 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 26, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 26, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 27, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 27, 4 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 28, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 28, 4 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 28, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 29, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 29, 4 });

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
                keyValues: new object[] { 32, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 33, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 33, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 34, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 34, 4 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 35, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 35, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 36, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 36, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 37, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 37, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 37, 8 });

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
                keyValues: new object[] { 40, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 41, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 41, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 42, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 42, 5 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 43, 3 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 43, 6 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 44, 2 });

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumns: new[] { "FoodID", "CategoryID" },
                keyValues: new object[] { 44, 5 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 8, 6 });

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
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 14, 1 });

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
                keyValues: new object[] { 15, 5 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 16, 1 });

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
                keyValues: new object[] { 17, 4 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 19, 3 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 22, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 23, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 23, 6 });

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
                keyValues: new object[] { 25, 7 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 25, 8 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 26, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 26, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 26, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 27, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 27, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 28, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 28, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 29, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 29, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 30, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 30, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 35, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 35, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 35, 4 });

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
                keyValues: new object[] { 36, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 36, 4 });

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
                keyValues: new object[] { 39, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 39, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 40, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 40, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 41, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 41, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 41, 4 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 41, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 42, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 42, 2 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 42, 6 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 43, 7 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 44, 1 });

            migrationBuilder.DeleteData(
                table: "FoodSides",
                keyColumns: new[] { "FoodID", "SideID" },
                keyValues: new object[] { 44, 7 });

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
        }
    }
}
