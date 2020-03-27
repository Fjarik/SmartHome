using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Food : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "ID", "GlutenFree", "Name", "TypeID" },
                values: new object[,]
                {
                    { 1, true, "Kotlety na cibulce", 1 },
                    { 25, true, "Klobása", 1 },
                    { 26, true, "Kuřecí kapsa", 1 },
                    { 27, true, "Smažený sýr", 1 },
                    { 28, true, "Žampiony", 1 },
                    { 29, true, "Květák", 1 },
                    { 30, true, "Holandký řízek", 1 },
                    { 31, true, "Halušky", 1 },
                    { 32, true, "Špagety", 1 },
                    { 33, true, "Těstoviny stuňákem", 1 },
                    { 34, true, "Bramboráky", 1 },
                    { 35, true, "Roláda kuřecí", 1 },
                    { 36, true, "Roláda vepřová", 1 },
                    { 37, true, "Dušení mrkev + maso", 1 },
                    { 38, true, "Čína", 1 },
                    { 39, true, "Karbanátky", 1 },
                    { 40, true, "Čevabčiči", 1 },
                    { 41, true, "Kuřecí plátek v alobalu", 1 },
                    { 42, true, "Johančino tajemství", 1 },
                    { 43, true, "Čočka na kyselo", 1 },
                    { 24, true, "Kuře s nádivkou", 1 },
                    { 44, true, "Míchaná zelenina", 1 },
                    { 23, true, "Maso zapečené s kečupem", 1 },
                    { 21, true, "Zapečné brambory", 1 },
                    { 2, true, "Ražniči", 1 },
                    { 3, true, "Naložené kuřecí plátky", 1 },
                    { 4, true, "Naložené vepřové plátky", 1 },
                    { 5, true, "Knedlo, vepřo, zelo", 1 },
                    { 6, true, "Knedlo, vepřo, špenát", 1 },
                    { 7, true, "Špenát s vajíčkem", 1 },
                    { 8, true, "Řízky", 1 },
                    { 9, true, "Filé", 1 },
                    { 10, true, "Sekaná", 1 },
                    { 11, true, "Rizoto kuřecí", 1 },
                    { 12, true, "Rizoto vepřové", 1 },
                    { 13, true, "Kuře na papirce", 1 },
                    { 14, true, "Rajská", 1 },
                    { 15, true, "Guláš", 1 },
                    { 16, true, "Buřt guláš", 1 },
                    { 17, true, "Ptáčky", 1 },
                    { 18, true, "Houbová omáčka", 1 },
                    { 19, true, "Koprovka", 1 },
                    { 20, true, "Šunkafleky", 1 },
                    { 22, true, "Maso ve smetanové omáčce", 1 },
                    { 45, true, "Pečené maso", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
