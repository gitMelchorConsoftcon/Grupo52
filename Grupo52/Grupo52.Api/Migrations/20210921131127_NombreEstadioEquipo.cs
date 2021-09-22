using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupo52.Api.Migrations
{
    public partial class NombreEstadioEquipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreEstadio",
                table: "Equipos",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreEstadio",
                table: "Equipos");
        }
    }
}
