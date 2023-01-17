using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeria.Migrations
{
    /// <inheritdoc />
    public partial class EsperimentoEntityFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Categorie_CategoriaNome",
                table: "Pizze");

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaNome",
                table: "Pizze",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_Categorie_CategoriaNome",
                table: "Pizze",
                column: "CategoriaNome",
                principalTable: "Categorie",
                principalColumn: "Nome",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Categorie_CategoriaNome",
                table: "Pizze");

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaNome",
                table: "Pizze",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_Categorie_CategoriaNome",
                table: "Pizze",
                column: "CategoriaNome",
                principalTable: "Categorie",
                principalColumn: "Nome");
        }
    }
}
