using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejemplo01.Migrations
{
    public partial class AddRutaFoto_Amigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RutaFoto",
                table: "Amigos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RutaFoto",
                table: "Amigos");
        }
    }
}
