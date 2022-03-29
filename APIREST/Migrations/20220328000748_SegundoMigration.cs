using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIREST.Migrations
{
    public partial class SegundoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    matricula = table.Column<int>(type: "int", nullable: true),
                    profissao = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Prontoario = table.Column<string>(type: "nvarchar(600)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(600)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAtendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: true),
                    AtendenteId = table.Column<int>(type: "int", nullable: true),
                    ProcedimentoMedicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Pessoas_AtendenteId",
                        column: x => x.AtendenteId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Pessoas_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Procedimentos_ProcedimentoMedicoId",
                        column: x => x.ProcedimentoMedicoId,
                        principalTable: "Procedimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_AtendenteId",
                table: "Atendimentos",
                column: "AtendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_MedicoId",
                table: "Atendimentos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_ProcedimentoMedicoId",
                table: "Atendimentos",
                column: "ProcedimentoMedicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Procedimentos");
        }
    }
}
