using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaChurrascosApi.Migrations
{
    /// <inheritdoc />
    public partial class modelsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChurrascoGuarnicion_Churrascos_ChurrascoId",
                table: "ChurrascoGuarnicion");

            migrationBuilder.DropForeignKey(
                name: "FK_ChurrascoGuarnicion_Guarnicion_GuarnicionId",
                table: "ChurrascoGuarnicion");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboChurrasco_Churrascos_ChurrascoId",
                table: "ComboChurrasco");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboChurrasco_Combos_ComboId",
                table: "ComboChurrasco");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboDulce_Combos_ComboId",
                table: "ComboDulce");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboDulce_Dulces_DulceTipicoId",
                table: "ComboDulce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guarnicion",
                table: "Guarnicion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComboDulce",
                table: "ComboDulce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComboChurrasco",
                table: "ComboChurrasco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChurrascoGuarnicion",
                table: "ChurrascoGuarnicion");

            migrationBuilder.RenameTable(
                name: "Guarnicion",
                newName: "Guarniciones");

            migrationBuilder.RenameTable(
                name: "ComboDulce",
                newName: "ComboDulces");

            migrationBuilder.RenameTable(
                name: "ComboChurrasco",
                newName: "ComboChurrascos");

            migrationBuilder.RenameTable(
                name: "ChurrascoGuarnicion",
                newName: "ChurrascoGuarniciones");

            migrationBuilder.RenameIndex(
                name: "IX_ComboDulce_DulceTipicoId",
                table: "ComboDulces",
                newName: "IX_ComboDulces_DulceTipicoId");

            migrationBuilder.RenameIndex(
                name: "IX_ComboDulce_ComboId",
                table: "ComboDulces",
                newName: "IX_ComboDulces_ComboId");

            migrationBuilder.RenameIndex(
                name: "IX_ComboChurrasco_ComboId",
                table: "ComboChurrascos",
                newName: "IX_ComboChurrascos_ComboId");

            migrationBuilder.RenameIndex(
                name: "IX_ComboChurrasco_ChurrascoId",
                table: "ComboChurrascos",
                newName: "IX_ComboChurrascos_ChurrascoId");

            migrationBuilder.RenameIndex(
                name: "IX_ChurrascoGuarnicion_GuarnicionId",
                table: "ChurrascoGuarniciones",
                newName: "IX_ChurrascoGuarniciones_GuarnicionId");

            migrationBuilder.RenameIndex(
                name: "IX_ChurrascoGuarnicion_ChurrascoId",
                table: "ChurrascoGuarniciones",
                newName: "IX_ChurrascoGuarniciones_ChurrascoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guarniciones",
                table: "Guarniciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComboDulces",
                table: "ComboDulces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComboChurrascos",
                table: "ComboChurrascos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChurrascoGuarniciones",
                table: "ChurrascoGuarniciones",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ConsumoCarnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoCarne = table.Column<string>(type: "TEXT", nullable: false),
                    LibrasPorPorcion = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoCarnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecetaGuarniciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Guarnicion = table.Column<string>(type: "TEXT", nullable: false),
                    UnidadInventario = table.Column<string>(type: "TEXT", nullable: false),
                    CantidadPorPorcion = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaGuarniciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidoChurrascos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChurrascoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoChurrascos", x => new { x.PedidoId, x.ChurrascoId });
                    table.ForeignKey(
                        name: "FK_PedidoChurrascos_Churrascos_ChurrascoId",
                        column: x => x.ChurrascoId,
                        principalTable: "Churrascos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoChurrascos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoDulces",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DulceTipicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    TamañoCaja = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDulces", x => new { x.PedidoId, x.DulceTipicoId });
                    table.ForeignKey(
                        name: "FK_PedidoDulces_Dulces_DulceTipicoId",
                        column: x => x.DulceTipicoId,
                        principalTable: "Dulces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoDulces_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoChurrascos_ChurrascoId",
                table: "PedidoChurrascos",
                column: "ChurrascoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDulces_DulceTipicoId",
                table: "PedidoDulces",
                column: "DulceTipicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChurrascoGuarniciones_Churrascos_ChurrascoId",
                table: "ChurrascoGuarniciones",
                column: "ChurrascoId",
                principalTable: "Churrascos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChurrascoGuarniciones_Guarniciones_GuarnicionId",
                table: "ChurrascoGuarniciones",
                column: "GuarnicionId",
                principalTable: "Guarniciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboChurrascos_Churrascos_ChurrascoId",
                table: "ComboChurrascos",
                column: "ChurrascoId",
                principalTable: "Churrascos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboChurrascos_Combos_ComboId",
                table: "ComboChurrascos",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboDulces_Combos_ComboId",
                table: "ComboDulces",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboDulces_Dulces_DulceTipicoId",
                table: "ComboDulces",
                column: "DulceTipicoId",
                principalTable: "Dulces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChurrascoGuarniciones_Churrascos_ChurrascoId",
                table: "ChurrascoGuarniciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ChurrascoGuarniciones_Guarniciones_GuarnicionId",
                table: "ChurrascoGuarniciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboChurrascos_Churrascos_ChurrascoId",
                table: "ComboChurrascos");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboChurrascos_Combos_ComboId",
                table: "ComboChurrascos");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboDulces_Combos_ComboId",
                table: "ComboDulces");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboDulces_Dulces_DulceTipicoId",
                table: "ComboDulces");

            migrationBuilder.DropTable(
                name: "ConsumoCarnes");

            migrationBuilder.DropTable(
                name: "PedidoChurrascos");

            migrationBuilder.DropTable(
                name: "PedidoDulces");

            migrationBuilder.DropTable(
                name: "RecetaGuarniciones");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guarniciones",
                table: "Guarniciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComboDulces",
                table: "ComboDulces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComboChurrascos",
                table: "ComboChurrascos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChurrascoGuarniciones",
                table: "ChurrascoGuarniciones");

            migrationBuilder.RenameTable(
                name: "Guarniciones",
                newName: "Guarnicion");

            migrationBuilder.RenameTable(
                name: "ComboDulces",
                newName: "ComboDulce");

            migrationBuilder.RenameTable(
                name: "ComboChurrascos",
                newName: "ComboChurrasco");

            migrationBuilder.RenameTable(
                name: "ChurrascoGuarniciones",
                newName: "ChurrascoGuarnicion");

            migrationBuilder.RenameIndex(
                name: "IX_ComboDulces_DulceTipicoId",
                table: "ComboDulce",
                newName: "IX_ComboDulce_DulceTipicoId");

            migrationBuilder.RenameIndex(
                name: "IX_ComboDulces_ComboId",
                table: "ComboDulce",
                newName: "IX_ComboDulce_ComboId");

            migrationBuilder.RenameIndex(
                name: "IX_ComboChurrascos_ComboId",
                table: "ComboChurrasco",
                newName: "IX_ComboChurrasco_ComboId");

            migrationBuilder.RenameIndex(
                name: "IX_ComboChurrascos_ChurrascoId",
                table: "ComboChurrasco",
                newName: "IX_ComboChurrasco_ChurrascoId");

            migrationBuilder.RenameIndex(
                name: "IX_ChurrascoGuarniciones_GuarnicionId",
                table: "ChurrascoGuarnicion",
                newName: "IX_ChurrascoGuarnicion_GuarnicionId");

            migrationBuilder.RenameIndex(
                name: "IX_ChurrascoGuarniciones_ChurrascoId",
                table: "ChurrascoGuarnicion",
                newName: "IX_ChurrascoGuarnicion_ChurrascoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guarnicion",
                table: "Guarnicion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComboDulce",
                table: "ComboDulce",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComboChurrasco",
                table: "ComboChurrasco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChurrascoGuarnicion",
                table: "ChurrascoGuarnicion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChurrascoGuarnicion_Churrascos_ChurrascoId",
                table: "ChurrascoGuarnicion",
                column: "ChurrascoId",
                principalTable: "Churrascos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChurrascoGuarnicion_Guarnicion_GuarnicionId",
                table: "ChurrascoGuarnicion",
                column: "GuarnicionId",
                principalTable: "Guarnicion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboChurrasco_Churrascos_ChurrascoId",
                table: "ComboChurrasco",
                column: "ChurrascoId",
                principalTable: "Churrascos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboChurrasco_Combos_ComboId",
                table: "ComboChurrasco",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboDulce_Combos_ComboId",
                table: "ComboDulce",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboDulce_Dulces_DulceTipicoId",
                table: "ComboDulce",
                column: "DulceTipicoId",
                principalTable: "Dulces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
