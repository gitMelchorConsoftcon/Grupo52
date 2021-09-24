using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupo52.Api.Migrations
{
    public partial class CampoActivoJugadorEquipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Jugadores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Equipos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Equipos");
        }
    }
}
