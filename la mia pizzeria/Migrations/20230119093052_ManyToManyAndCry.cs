using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeria.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyAndCry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "CondimentiPizze",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    CondimentoExtraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondimentiPizze", x => new { x.PizzaId, x.CondimentoExtraId });
                    table.ForeignKey(
                        name: "FK_CondimentiPizze_CondimentiExtra_CondimentoExtraId",
                        column: x => x.CondimentoExtraId,
                        principalTable: "CondimentiExtra",
                        principalColumn: "CondimentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondimentiPizze_Pizze_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_CondimentiPizze_CondimentoExtraId",
                table: "CondimentiPizze",
                column: "CondimentoExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_CondimentoExtraPizza_PizzeConditeId",
                table: "CondimentoExtraPizza",
                column: "PizzeConditeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CondimentiPizze");

            migrationBuilder.DropTable(
                name: "CondimentoExtraPizza");

            migrationBuilder.DropTable(
                name: "CondimentiExtra");
        }
    }
}
