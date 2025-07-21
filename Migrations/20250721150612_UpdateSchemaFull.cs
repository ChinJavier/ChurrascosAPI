using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaChurrascosApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaFull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Churrascos_Combos_ComboId",
                table: "Churrascos");

            migrationBuilder.DropForeignKey(
                name: "FK_Dulces_Combos_ComboId",
                table: "Dulces");

            migrationBuilder.DropIndex(
                name: "IX_Dulces_ComboId",
                table: "Dulces");

            migrationBuilder.DropIndex(
                name: "IX_Churrascos_ComboId",
                table: "Churrascos");

            migrationBuilder.DropColumn(
                name: "ComboId",
                table: "Dulces");

            migrationBuilder.DropColumn(
                name: "ComboId",
                table: "Churrascos");

            migrationBuilder.RenameColumn(
                name: "Guarniciones",
                table: "Churrascos",
                newName: "TotalPrecio");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioTotal",
                table: "Combos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Combos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ComboChurrasco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComboId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChurrascoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboChurrasco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboChurrasco_Churrascos_ChurrascoId",
                        column: x => x.ChurrascoId,
                        principalTable: "Churrascos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboChurrasco_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboDulce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComboId = table.Column<int>(type: "INTEGER", nullable: false),
                    DulceTipicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TamañoCaja = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboDulce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboDulce_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboDulce_Dulces_DulceTipicoId",
                        column: x => x.DulceTipicoId,
                        principalTable: "Dulces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guarnicion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guarnicion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChurrascoGuarnicion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChurrascoId = table.Column<int>(type: "INTEGER", nullable: false),
                    GuarnicionId = table.Column<int>(type: "INTEGER", nullable: false),
                    EsExtra = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChurrascoGuarnicion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChurrascoGuarnicion_Churrascos_ChurrascoId",
                        column: x => x.ChurrascoId,
                        principalTable: "Churrascos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChurrascoGuarnicion_Guarnicion_GuarnicionId",
                        column: x => x.GuarnicionId,
                        principalTable: "Guarnicion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChurrascoGuarnicion_ChurrascoId",
                table: "ChurrascoGuarnicion",
                column: "ChurrascoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChurrascoGuarnicion_GuarnicionId",
                table: "ChurrascoGuarnicion",
                column: "GuarnicionId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboChurrasco_ChurrascoId",
                table: "ComboChurrasco",
                column: "ChurrascoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboChurrasco_ComboId",
                table: "ComboChurrasco",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDulce_ComboId",
                table: "ComboDulce",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDulce_DulceTipicoId",
                table: "ComboDulce",
                column: "DulceTipicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChurrascoGuarnicion");

            migrationBuilder.DropTable(
                name: "ComboChurrasco");

            migrationBuilder.DropTable(
                name: "ComboDulce");

            migrationBuilder.DropTable(
                name: "Guarnicion");

            migrationBuilder.DropColumn(
                name: "PrecioTotal",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Combos");

            migrationBuilder.RenameColumn(
                name: "TotalPrecio",
                table: "Churrascos",
                newName: "Guarniciones");

            migrationBuilder.AddColumn<int>(
                name: "ComboId",
                table: "Dulces",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComboId",
                table: "Churrascos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dulces_ComboId",
                table: "Dulces",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_Churrascos_ComboId",
                table: "Churrascos",
                column: "ComboId");

            migrationBuilder.AddForeignKey(
                name: "FK_Churrascos_Combos_ComboId",
                table: "Churrascos",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dulces_Combos_ComboId",
                table: "Dulces",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id");
        }
    }
}
