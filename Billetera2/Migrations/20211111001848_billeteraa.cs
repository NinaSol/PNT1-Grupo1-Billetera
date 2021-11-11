using Microsoft.EntityFrameworkCore.Migrations;

namespace Billetera2.Migrations
{
    public partial class billeteraa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoMovimiento",
                table: "Movimientos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoMovimiento",
                table: "Movimientos");
        }
    }
}
