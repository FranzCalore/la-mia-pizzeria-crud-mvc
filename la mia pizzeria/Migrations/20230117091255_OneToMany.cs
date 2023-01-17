using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeria.Migrations
{
    /// <inheritdoc />
    public partial class OneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prezzo",
                table: "Pizze",
                newName: "Prezzo");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Pizze",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "immagine",
                table: "Pizze",
                newName: "Immagine");

            migrationBuilder.RenameColumn(
                name: "descrizione",
                table: "Pizze",
                newName: "Descrizione");

            migrationBuilder.AddColumn<string>(
                name: "CategoriaNomeCategoria",
                table: "Pizze",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeCategoria",
                table: "Pizze",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    NomeCategoria = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.NomeCategoria);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizze_CategoriaNomeCategoria",
                table: "Pizze",
                column: "CategoriaNomeCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_Categorie_CategoriaNomeCategoria",
                table: "Pizze",
                column: "CategoriaNomeCategoria",
                principalTable: "Categorie",
                principalColumn: "NomeCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Categorie_CategoriaNomeCategoria",
                table: "Pizze");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Pizze_CategoriaNomeCategoria",
                table: "Pizze");

            migrationBuilder.DropColumn(
                name: "CategoriaNomeCategoria",
                table: "Pizze");

            migrationBuilder.DropColumn(
                name: "NomeCategoria",
                table: "Pizze");

            migrationBuilder.RenameColumn(
                name: "Prezzo",
                table: "Pizze",
                newName: "prezzo");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Pizze",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Immagine",
                table: "Pizze",
                newName: "immagine");

            migrationBuilder.RenameColumn(
                name: "Descrizione",
                table: "Pizze",
                newName: "descrizione");
        }
    }
}
