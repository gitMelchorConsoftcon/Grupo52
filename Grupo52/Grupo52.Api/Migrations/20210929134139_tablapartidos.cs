using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupo52.Api.Migrations
{
    public partial class tablapartidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    IdPartido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEquipoLocal = table.Column<int>(type: "int", nullable: false),
                    IdEquipoVisitante = table.Column<int>(type: "int", nullable: false),
                    GolLocal = table.Column<int>(type: "int", nullable: false),
                    GolVisitante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.IdPartido);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_IdEquipoLocal",
                        column: x => x.IdEquipoLocal,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_IdEquipoVisitante",
                        column: x => x.IdEquipoVisitante,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_IdEquipoLocal",
                table: "Partidos",
                column: "IdEquipoLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_IdEquipoVisitante",
                table: "Partidos",
                column: "IdEquipoVisitante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partidos");
        }
    }
}
