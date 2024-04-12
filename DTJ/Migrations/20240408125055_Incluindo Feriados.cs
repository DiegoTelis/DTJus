using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTJ.Migrations
{
    /// <inheritdoc />
    public partial class IncluindoFeriados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumProtocolo",
                table: "Tarefa",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Feriados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Local = table.Column<string>(type: "TEXT", nullable: false),
                    Dia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiaSemana = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    FeriadoDesc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feriados", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feriados");

            migrationBuilder.DropColumn(
                name: "NumProtocolo",
                table: "Tarefa");
        }
    }
}
