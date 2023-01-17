using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lamiapizzeria.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Categorie_CategoriaNomeCategoria",
                table: "Pizze");

            migrationBuilder.DropIndex(
                name: "IX_Pizze_CategoriaNomeCategoria",
                table: "Pizze");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie");

            migrationBuilder.DropColumn(
                name: "CategoriaNomeCategoria",
                table: "Pizze");

            migrationBuilder.DropColumn(
                name: "NomeCategoria",
                table: "Pizze");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Pizze",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeCategoria",
                table: "Categorie",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Categorie",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizze_CategoriaId",
                table: "Pizze",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_Categorie_CategoriaId",
                table: "Pizze",
                column: "CategoriaId",
                principalTable: "Categorie",
                principalColumn: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_Categorie_CategoriaId",
                table: "Pizze");

            migrationBuilder.DropIndex(
                name: "IX_Pizze_CategoriaId",
                table: "Pizze");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Pizze");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Categorie");

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

            migrationBuilder.AlterColumn<string>(
                name: "NomeCategoria",
                table: "Categorie",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie",
                column: "NomeCategoria");

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
    }
}
