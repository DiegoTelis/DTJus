using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTJ.Migrations
{
    /// <inheritdoc />
    public partial class tarefas02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Tarefa",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_PessoaId",
                table: "Tarefa",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Pessoa_PessoaId",
                table: "Tarefa",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Pessoa_PessoaId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_PessoaId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Tarefa");
        }
    }
}
