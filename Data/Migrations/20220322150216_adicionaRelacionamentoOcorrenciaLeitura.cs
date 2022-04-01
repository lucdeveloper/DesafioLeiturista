using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class adicionaRelacionamentoOcorrenciaLeitura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LeituraId",
                table: "Ocorrencia",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OcorrenciaId",
                table: "Leitura",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_LeituraId",
                table: "Ocorrencia",
                column: "LeituraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Leitura_LeituraId",
                table: "Ocorrencia",
                column: "LeituraId",
                principalTable: "Leitura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Leitura_LeituraId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_LeituraId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "LeituraId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "OcorrenciaId",
                table: "Leitura");
        }
    }
}
