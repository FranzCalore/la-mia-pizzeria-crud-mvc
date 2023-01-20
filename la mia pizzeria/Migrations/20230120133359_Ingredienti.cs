using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeria.Migrations
{
    /// <inheritdoc />
    public partial class Ingredienti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CondimentoExtraPizza");

            migrationBuilder.DropTable(
                name: "CondimentiExtra");

            migrationBuilder.CreateTable(
                name: "Ingredienti",
                columns: table => new
                {
                    IngredienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condimento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredienti", x => x.IngredienteId);
                });

            migrationBuilder.CreateTable(
                name: "IngredientePizza",
                columns: table => new
                {
                    IngredientiIngredienteId = table.Column<int>(type: "int", nullable: false),
                    PizzeConditeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientePizza", x => new { x.IngredientiIngredienteId, x.PizzeConditeId });
                    table.ForeignKey(
                        name: "FK_IngredientePizza_Ingredienti_IngredientiIngredienteId",
                        column: x => x.IngredientiIngredienteId,
                        principalTable: "Ingredienti",
                        principalColumn: "IngredienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientePizza_Pizze_PizzeConditeId",
                        column: x => x.PizzeConditeId,
                        principalTable: "Pizze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientePizza_PizzeConditeId",
                table: "IngredientePizza",
                column: "PizzeConditeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientePizza");

            migrationBuilder.DropTable(
                name: "Ingredienti");

            migrationBuilder.CreateTable(
                name: "CondimentiExtra",
                columns: table => new
                {
                    CondimentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrezzoCondimento = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondimentiExtra", x => x.CondimentoId);
                });

            migrationBuilder.CreateTable(
                name: "CondimentoExtraPizza",
                columns: table => new
                {
                    CondimentiExtraCondimentoId = table.Column<int>(type: "int", nullable: false),
                    PizzeConditeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondimentoExtraPizza", x => new { x.CondimentiExtraCondimentoId, x.PizzeConditeId });
                    table.ForeignKey(
                        name: "FK_CondimentoExtraPizza_CondimentiExtra_CondimentiExtraCondimentoId",
                        column: x => x.CondimentiExtraCondimentoId,
                        principalTable: "CondimentiExtra",
                        principalColumn: "CondimentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondimentoExtraPizza_Pizze_PizzeConditeId",
                        column: x => x.PizzeConditeId,
                        principalTable: "Pizze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CondimentoExtraPizza_PizzeConditeId",
                table: "CondimentoExtraPizza",
                column: "PizzeConditeId");
        }
    }
}
