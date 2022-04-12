using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIREST.Migrations
{
    public partial class AtualizaçãoAtendimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAgenda",
                table: "Atendimentos");

            migrationBuilder.AddColumn<string>(
                name: "DescricaoProcedmento",
                table: "Atendimentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeAtend",
                table: "Atendimentos",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeMedico",
                table: "Atendimentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomePaciente",
                table: "Atendimentos",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorProcedimento",
                table: "Atendimentos",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoProcedmento",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "NomeAtend",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "NomeMedico",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "NomePaciente",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "ValorProcedimento",
                table: "Atendimentos");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAgenda",
                table: "Atendimentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
