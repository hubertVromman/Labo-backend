using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "livres");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "livres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomGenre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.GenreId);
                });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "GenreId", "NomGenre" },
                values: new object[,]
                {
                    { -3, "Thriller" },
                    { -2, "Romantique" },
                    { -1, "Porno" }
                });

            migrationBuilder.UpdateData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -3,
                column: "GenreId",
                value: -1);

            migrationBuilder.UpdateData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -2,
                column: "GenreId",
                value: -2);

            migrationBuilder.UpdateData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -1,
                column: "GenreId",
                value: -3);

            migrationBuilder.CreateIndex(
                name: "IX_livres_GenreId",
                table: "livres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livre_Genre",
                table: "livres",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livre_Genre",
                table: "livres");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropIndex(
                name: "IX_livres_GenreId",
                table: "livres");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "livres");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "livres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -3,
                column: "Genre",
                value: "Porno");

            migrationBuilder.UpdateData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -2,
                column: "Genre",
                value: "Romantique");

            migrationBuilder.UpdateData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -1,
                column: "Genre",
                value: "Thriller");
        }
    }
}
