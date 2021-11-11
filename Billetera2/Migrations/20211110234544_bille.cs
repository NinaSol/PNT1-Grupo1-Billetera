using Microsoft.EntityFrameworkCore.Migrations;

namespace Billetera2.Migrations
{
    public partial class bille : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoMovimiento",
                table: "Movimientos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoMovimiento",
                table: "Movimientos",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }
    }
}
