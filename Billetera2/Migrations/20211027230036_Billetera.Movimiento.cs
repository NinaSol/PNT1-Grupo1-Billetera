using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billetera2.Migrations
{
    public partial class BilleteraMovimiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Monto = table.Column<double>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 180, nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoMovimiento = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");
        }
    }
}
