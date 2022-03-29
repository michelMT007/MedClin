using Microsoft.EntityFrameworkCore.Migrations;

namespace APIREST.Migrations
{
    public partial class AtendimentoPacienteCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteAtendidoId",
                table: "Atendimentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_PacienteAtendidoId",
                table: "Atendimentos",
                column: "PacienteAtendidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Pessoas_PacienteAtendidoId",
                table: "Atendimentos",
                column: "PacienteAtendidoId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Pessoas_PacienteAtendidoId",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_PacienteAtendidoId",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "PacienteAtendidoId",
                table: "Atendimentos");
        }
    }
}
