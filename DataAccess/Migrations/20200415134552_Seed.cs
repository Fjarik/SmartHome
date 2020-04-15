using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Seed : Migration
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
                table: "Foods",
                columns: new[] { "ID", "GlutenFree", "Name", "TypeID" },
                values: new object[,]
                {
                    { 42, true, "Bramboráky", 1 },
                    { 41, true, "Těstoviny stuňákem", 1 },
                    { 40, true, "Špagety", 1 },
                    { 39, true, "Halušky", 1 },
                    { 38, true, "Holandký řízek", 1 },
                    { 33, true, "Klobása", 1 },
                    { 36, true, "Žampiony", 1 },
                    { 35, true, "Smažený sýr", 1 },
                    { 34, true, "Kuřecí kapsa", 1 },
                    { 43, true, "Roláda kuřecí", 1 },
                    { 32, true, "Kuře s nádivkou", 1 },
                    { 37, true, "Květák", 1 },
                    { 44, true, "Roláda vepřová", 1 },
                    { 49, true, "Kuřecí plátek v alobalu", 1 },
                    { 46, true, "Čína", 1 },
                    { 47, true, "Karbanátky", 1 },
                    { 48, true, "Čevabčiči", 1 },
                    { 31, true, "Maso zapečené s kečupem", 1 },
                    { 50, true, "Johančino tajemství", 1 },
                    { 51, true, "Čočka na kyselo", 1 },
                    { 52, true, "Míchaná zelenina", 1 },
                    { 53, true, "Pečené maso", 1 },
                    { 54, true, "Buřtgulášová polévka", 2 },
                    { 55, true, "Česnečka", 2 },
                    { 56, true, "Bramboračka", 2 },
                    { 57, true, "Pórková polévka", 2 },
                    { 58, true, "Houbová polévka", 2 },
                    { 45, true, "Dušení mrkev + maso", 1 },
                    { 30, true, "Maso ve smetanové omáčce", 1 },
                    { 25, true, "Ptáčky", 1 },
                    { 28, true, "Šunkafleky", 1 },
                    { 1, true, "Brambory", 4 },
                    { 2, true, "Bramborová kaše", 4 },
                    { 3, true, "Knedlíky", 4 },
                    { 4, true, "Rýže", 4 },
                    { 5, true, "Těstoviny", 4 },
                    { 6, true, "Hranolky", 4 },
                    { 7, true, "Pečivo", 4 },
                    { 8, true, "Zelenina", 4 },
                    { 9, true, "Kotlety na cibulce", 1 },
                    { 10, true, "Ražniči", 1 },
                    { 11, true, "Naložené kuřecí plátky", 1 },
                    { 12, true, "Naložené vepřové plátky", 1 },
                    { 13, true, "Knedlo, vepřo, zelo", 1 },
                    { 14, true, "Knedlo, vepřo, špenát", 1 },
                    { 15, true, "Špenát s vajíčkem", 1 },
                    { 16, true, "Řízky", 1 },
                    { 17, true, "Filé", 1 },
                    { 18, true, "Sekaná", 1 },
                    { 19, true, "Rizoto kuřecí", 1 },
                    { 20, true, "Rizoto vepřové", 1 },
                    { 21, true, "Kuře na papirce", 1 },
                    { 22, true, "Rajská", 1 },
                    { 23, true, "Guláš", 1 },
                    { 24, true, "Buřt guláš", 1 },
                    { 59, true, "Polévka z kuřecího vývaru", 2 },
                    { 26, true, "Houbová omáčka", 1 },
                    { 27, true, "Koprovka", 1 },
                    { 29, true, "Zapečné brambory", 1 },
                    { 60, true, "Špenátová polévka", 2 }
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
                table: "Foods",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 60);
        }
    }
}
