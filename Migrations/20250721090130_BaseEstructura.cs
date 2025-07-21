using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaChurrascosApi.Migrations
{
    /// <inheritdoc />
    public partial class BaseEstructura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComboId",
                table: "Churrascos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Unidad = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dulces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    PrecioUnidad = table.Column<decimal>(type: "TEXT", nullable: false),
                    PrecioCaja6 = table.Column<decimal>(type: "TEXT", nullable: false),
                    PrecioCaja12 = table.Column<decimal>(type: "TEXT", nullable: false),
                    PrecioCaja24 = table.Column<decimal>(type: "TEXT", nullable: false),
                    ComboId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dulces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dulces_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Churrascos_ComboId",
                table: "Churrascos",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_Dulces_ComboId",
                table: "Dulces",
                column: "ComboId");

            migrationBuilder.AddForeignKey(
                name: "FK_Churrascos_Combos_ComboId",
                table: "Churrascos",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Churrascos_Combos_ComboId",
                table: "Churrascos");

            migrationBuilder.DropTable(
                name: "Dulces");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropIndex(
                name: "IX_Churrascos_ComboId",
                table: "Churrascos");

            migrationBuilder.DropColumn(
                name: "ComboId",
                table: "Churrascos");
        }
    }
}
