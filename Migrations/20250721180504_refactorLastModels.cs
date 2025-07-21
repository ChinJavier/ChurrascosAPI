using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaChurrascosApi.Migrations
{
    /// <inheritdoc />
    public partial class refactorLastModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecioTotal",
                table: "Combos",
                newName: "Precio");

            migrationBuilder.AddColumn<int>(
                name: "CantidadCombo",
                table: "Pedidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComboId",
                table: "Pedidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TamañoCaja",
                table: "PedidoDulces",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PedidoDulces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PedidoChurrascos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Combos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Combos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "TamañoCaja",
                table: "ComboDulces",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "ComboDulces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ComboId",
                table: "Pedidos",
                column: "ComboId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Combos_ComboId",
                table: "Pedidos",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Combos_ComboId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ComboId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "CantidadCombo",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ComboId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PedidoDulces");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PedidoChurrascos");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "ComboDulces");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Combos",
                newName: "PrecioTotal");

            migrationBuilder.AlterColumn<int>(
                name: "TamañoCaja",
                table: "PedidoDulces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Combos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Combos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TamañoCaja",
                table: "ComboDulces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
