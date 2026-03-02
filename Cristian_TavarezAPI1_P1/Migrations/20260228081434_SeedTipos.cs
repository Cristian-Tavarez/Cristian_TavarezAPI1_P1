using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cristian_TavarezAPI1_P1.Migrations
{
    /// <inheritdoc />
    public partial class SeedTipos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TiposHuacales",
                columns: new[] { "TipoId", "Descripcion", "Existencia" },
                values: new object[,]
                {
                    { 1, "Rojo", 0 },
                    { 2, "Verde", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiposHuacales",
                keyColumn: "TipoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposHuacales",
                keyColumn: "TipoId",
                keyValue: 2);
        }
    }
}
