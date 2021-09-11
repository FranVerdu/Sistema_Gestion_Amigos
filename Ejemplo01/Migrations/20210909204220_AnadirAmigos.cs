using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejemplo01.Migrations
{
    public partial class AnadirAmigos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Amigos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "pepe@algo.com");

            migrationBuilder.InsertData(
                table: "Amigos",
                columns: new[] { "Id", "Ciudad", "Email", "Nombre" },
                values: new object[] { 2, 3, "julia@algo.com", "Julia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amigos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Amigos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "mail@algo.com");
        }
    }
}
