using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaChurrascosApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Churrascos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoCarne = table.Column<string>(type: "TEXT", nullable: false),
                    Termino = table.Column<string>(type: "TEXT", nullable: false),
                    Modalidad = table.Column<string>(type: "TEXT", nullable: false),
                    Porciones = table.Column<int>(type: "INTEGER", nullable: false),
                    Guarniciones = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Churrascos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Churrascos");
        }
    }
}
