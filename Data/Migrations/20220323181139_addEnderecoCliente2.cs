using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addEnderecoCliente2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Endereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdCliente",
                table: "Endereco",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
