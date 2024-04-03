using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTJ.Migrations
{
    /// <inheritdoc />
    public partial class IncluidoAReceber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasAReceber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    TipoRecebimento = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorBase = table.Column<double>(type: "REAL", nullable: false),
                    Adicional = table.Column<double>(type: "REAL", nullable: false),
                    Desconto = table.Column<double>(type: "REAL", nullable: false),
                    ValorRecebido = table.Column<double>(type: "REAL", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataRecebimento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<char>(type: "TEXT", nullable: false),
                    Parcela = table.Column<int>(type: "INTEGER", nullable: false),
                    Observacao = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    TarefaId = table.Column<int>(type: "INTEGER", nullable: false),
                    PessoaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAReceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasAReceber_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContasAReceber_Tarefa_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_PessoaId",
                table: "ContasAReceber",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_TarefaId",
                table: "ContasAReceber",
                column: "TarefaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasAReceber");
        }
    }
}
