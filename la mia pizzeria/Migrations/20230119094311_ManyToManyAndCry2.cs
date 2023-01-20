using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeria.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyAndCry2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CondimentiPizze_CondimentiExtra_CondimentoExtraId",
                table: "CondimentiPizze");

            migrationBuilder.DropForeignKey(
                name: "FK_CondimentiPizze_Pizze_PizzaId",
                table: "CondimentiPizze");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CondimentiPizze",
                table: "CondimentiPizze");

            migrationBuilder.RenameTable(
                name: "CondimentiPizze",
                newName: "CondimentiExtraPizza");

            migrationBuilder.RenameIndex(
                name: "IX_CondimentiPizze_CondimentoExtraId",
                table: "CondimentiExtraPizza",
                newName: "IX_CondimentiExtraPizza_CondimentoExtraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CondimentiExtraPizza",
                table: "CondimentiExtraPizza",
                columns: new[] { "PizzaId", "CondimentoExtraId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CondimentiExtraPizza_CondimentiExtra_CondimentoExtraId",
                table: "CondimentiExtraPizza",
                column: "CondimentoExtraId",
                principalTable: "CondimentiExtra",
                principalColumn: "CondimentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CondimentiExtraPizza_Pizze_PizzaId",
                table: "CondimentiExtraPizza",
                column: "PizzaId",
                principalTable: "Pizze",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CondimentiExtraPizza_CondimentiExtra_CondimentoExtraId",
                table: "CondimentiExtraPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_CondimentiExtraPizza_Pizze_PizzaId",
                table: "CondimentiExtraPizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CondimentiExtraPizza",
                table: "CondimentiExtraPizza");

            migrationBuilder.RenameTable(
                name: "CondimentiExtraPizza",
                newName: "CondimentiPizze");

            migrationBuilder.RenameIndex(
                name: "IX_CondimentiExtraPizza_CondimentoExtraId",
                table: "CondimentiPizze",
                newName: "IX_CondimentiPizze_CondimentoExtraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CondimentiPizze",
                table: "CondimentiPizze",
                columns: new[] { "PizzaId", "CondimentoExtraId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CondimentiPizze_CondimentiExtra_CondimentoExtraId",
                table: "CondimentiPizze",
                column: "CondimentoExtraId",
                principalTable: "CondimentiExtra",
                principalColumn: "CondimentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CondimentiPizze_Pizze_PizzaId",
                table: "CondimentiPizze",
                column: "PizzaId",
                principalTable: "Pizze",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
