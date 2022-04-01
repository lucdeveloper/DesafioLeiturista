using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class adicionaRelacionamentoteste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeituraOcorrencia");

            migrationBuilder.CreateIndex(
                name: "IX_Leitura_OcorrenciaId",
                table: "Leitura",
                column: "OcorrenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leitura_Ocorrencia_OcorrenciaId",
                table: "Leitura",
                column: "OcorrenciaId",
                principalTable: "Ocorrencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leitura_Ocorrencia_OcorrenciaId",
                table: "Leitura");

            migrationBuilder.DropIndex(
                name: "IX_Leitura_OcorrenciaId",
                table: "Leitura");

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
    }
}
