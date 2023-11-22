using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCategorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblImagenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblImagenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isBlocked = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProductos_TblCategorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "TblCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblProductoImagen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdImg = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_TblProductos_IdCategoria",
                table: "TblProductos",
                column: "IdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblProductoImagen");

            migrationBuilder.DropTable(
                name: "TblUsuarios");

            migrationBuilder.DropTable(
                name: "TblImagenes");

            migrationBuilder.DropTable(
                name: "TblProductos");

            migrationBuilder.DropTable(
                name: "TblCategorias");
        }
    }
}
