using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addEnderecoCliente3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Leitura");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Leitura");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Latitude",
                table: "Leitura",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Longitude",
                table: "Leitura",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
