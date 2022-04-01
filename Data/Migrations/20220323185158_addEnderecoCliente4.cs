using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addEnderecoCliente4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cliente_ClienteId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_ClienteId",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Endereco",
                newName: "ClienteID");

            migrationBuilder.AlterColumn<long>(
                name: "ClienteID",
                table: "Endereco",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteID",
                table: "Endereco",
                column: "ClienteID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cliente_ClienteID",
                table: "Endereco",
                column: "ClienteID",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cliente_ClienteID",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_ClienteID",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "ClienteID",
                table: "Endereco",
                newName: "ClienteId");

            migrationBuilder.AlterColumn<long>(
                name: "ClienteId",
                table: "Endereco",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteId",
                table: "Endereco",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cliente_ClienteId",
                table: "Endereco",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
