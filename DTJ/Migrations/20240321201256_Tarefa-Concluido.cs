using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTJ.Migrations
{
    /// <inheritdoc />
    public partial class TarefaConcluido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Concluido",
                table: "Tarefa",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concluido",
                table: "Tarefa");
        }
    }
}
