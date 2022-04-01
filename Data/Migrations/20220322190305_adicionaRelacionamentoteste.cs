using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class adicionaRelacionamentoteste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "LeituraOcorrencia",
                columns: table => new
                {
                    LeituraId = table.Column<long>(type: "bigint", nullable: false),
                    OcorrenciaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeituraOcorrencia", x => new { x.LeituraId, x.OcorrenciaId });
                    table.ForeignKey(
                        name: "FK_LeituraOcorrencia_Leitura_LeituraId",
                        column: x => x.LeituraId,
                        principalTable: "Leitura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeituraOcorrencia_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LeituraOcorrencia_OcorrenciaId",
                table: "LeituraOcorrencia",
                column: "OcorrenciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeituraOcorrencia");

            migrationBuilder.AddColumn<long>(
                name: "LeituraId",
                table: "Ocorrencia",
                type: "bigint",
                nullable: true);

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
    }
}
