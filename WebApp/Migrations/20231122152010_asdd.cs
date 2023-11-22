using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class asdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblProductoImagen");

            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                table: "TblImagenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TblImagenes_IdProducto",
                table: "TblImagenes",
                column: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_TblImagenes_TblProductos_IdProducto",
                table: "TblImagenes",
                column: "IdProducto",
                principalTable: "TblProductos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblImagenes_TblProductos_IdProducto",
                table: "TblImagenes");

            migrationBuilder.DropIndex(
                name: "IX_TblImagenes_IdProducto",
                table: "TblImagenes");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "TblImagenes");

            migrationBuilder.CreateTable(
                name: "TblProductoImagen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdImg = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProductoImagen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProductoImagen_TblImagenes_IdImg",
                        column: x => x.IdImg,
                        principalTable: "TblImagenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblProductoImagen_TblProductos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "TblProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblProductoImagen_IdImg",
                table: "TblProductoImagen",
                column: "IdImg");

            migrationBuilder.CreateIndex(
                name: "IX_TblProductoImagen_IdProducto",
                table: "TblProductoImagen",
                column: "IdProducto");
        }
    }
}
