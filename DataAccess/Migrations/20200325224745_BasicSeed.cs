using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class BasicSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Description", "IsHealthy", "Name" },
                values: new object[,]
                {
                    { 1, "Všechna sladká jídla", false, "Sladké" },
                    { 2, "Jídla, která neobsahují maso", true, "Bezmasé" },
                    { 3, "Jídla s libovolným obsahem jakéhokoliv masa", null, "S masem" },
                    { 4, "Jídla, která byla upravena procesem smažením", false, "Smažené" },
                    { 5, "Jídla, která byla upravena procesem upečením", null, "Pečené" },
                    { 6, "Jídla, která byla upravena procesem vařením", null, "Vařené" },
                    { 7, "Jídla, která byla upravena procesem grilováním", false, "Grilované" },
                    { 8, "Jídla, která byla upravena procesem dušením", true, "Dušené" },
                    { 9, "Jídla, která jsou servírována s omáčkou", null, "S omáčkou" },
                    { 10, "Jídla, která jsou servírována se sosem", null, "Se sosem" }
                });

            migrationBuilder.InsertData(
                table: "FoodTypes",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 3, "", "Zákusek" },
                    { 1, "", "Hlavní jídlo" },
                    { 2, "", "Polévka" }
                });

            migrationBuilder.InsertData(
                table: "SideDishes",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 7, "", "Pečivo" },
                    { 1, "", "Brambory" },
                    { 2, "", "Bramborová kaše" },
                    { 3, "", "Knedlíky" },
                    { 4, "", "Rýže" },
                    { 5, "", "Těstoviny" },
                    { 6, "", "Hranolky" },
                    { 8, "", "Zelenina" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FoodTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodTypes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SideDishes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SideDishes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SideDishes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SideDishes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SideDishes",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SideDishes",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SideDishes",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SideDishes",
                keyColumn: "ID",
                keyValue: 8);
        }
    }
}
