using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIREST.Migrations
{
    public partial class refatorando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAtendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAgenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdAtendente = table.Column<int>(type: "int", nullable: false),
                    IdProcedimentoMedico = table.Column<int>(type: "int", nullable: false),
                    IdPacienteAtendido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    matricula = table.Column<int>(type: "int", nullable: true),
                    profissao = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Prontoario = table.Column<string>(type: "nvarchar(600)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(500)", nullable: true)
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
                    Descricao = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimentos", x => x.Id);
                });
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
