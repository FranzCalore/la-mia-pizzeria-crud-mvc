using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeria.Migrations
{
    /// <inheritdoc />
    public partial class CambiatoNomeColonna2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Categorie_CategoriaNomeCategoria",
                table: "Pizze");

            migrationBuilder.RenameColumn(
                name: "CategoriaNomeCategoria",
                table: "Pizze",
                newName: "CategoriaNome");

            migrationBuilder.RenameIndex(
                name: "IX_Pizze_CategoriaNomeCategoria",
                table: "Pizze",
                newName: "IX_Pizze_CategoriaNome");

            migrationBuilder.RenameColumn(
                name: "NomeCategoria",
                table: "Categorie",
                newName: "Nome");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_Categorie_CategoriaNome",
                table: "Pizze",
                column: "CategoriaNome",
                principalTable: "Categorie",
                principalColumn: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Categorie_CategoriaNome",
                table: "Pizze");

            migrationBuilder.RenameColumn(
                name: "CategoriaNome",
                table: "Pizze",
                newName: "CategoriaNomeCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_Pizze_CategoriaNome",
                table: "Pizze",
                newName: "IX_Pizze_CategoriaNomeCategoria");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Categorie",
                newName: "NomeCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_Categorie_CategoriaNomeCategoria",
                table: "Pizze",
                column: "CategoriaNomeCategoria",
                principalTable: "Categorie",
                principalColumn: "NomeCategoria");
        }
    }
}
