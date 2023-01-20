using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeria.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyAndCry4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CondimentiExtraPizza");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CondimentiExtraPizza",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    CondimentoExtraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondimentiExtraPizza", x => new { x.PizzaId, x.CondimentoExtraId });
                    table.ForeignKey(
                        name: "FK_CondimentiExtraPizza_CondimentiExtra_CondimentoExtraId",
                        column: x => x.CondimentoExtraId,
                        principalTable: "CondimentiExtra",
                        principalColumn: "CondimentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondimentiExtraPizza_Pizze_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CondimentiExtraPizza_CondimentoExtraId",
                table: "CondimentiExtraPizza",
                column: "CondimentoExtraId");
        }
    }
}
