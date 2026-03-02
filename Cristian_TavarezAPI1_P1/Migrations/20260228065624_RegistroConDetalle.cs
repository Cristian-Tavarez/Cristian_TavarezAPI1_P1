using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cristian_TavarezAPI1_P1.Migrations
{
    /// <inheritdoc />
    public partial class RegistroConDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposHuacales",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHuacales", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "EntradasHuacalesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntradaId = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasHuacalesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntradasHuacalesDetalle_EntradasHuacales_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "EntradasHuacales",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradasHuacalesDetalle_TiposHuacales_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TiposHuacales",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradasHuacalesDetalle_EntradaId",
                table: "EntradasHuacalesDetalle",
                column: "EntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasHuacalesDetalle_TipoId",
                table: "EntradasHuacalesDetalle",
                column: "TipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradasHuacalesDetalle");

            migrationBuilder.DropTable(
                name: "TiposHuacales");
        }
    }
}
