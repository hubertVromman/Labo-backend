using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "auteurs",
                columns: new[] { "AuteurId", "Nom", "Prenom" },
                values: new object[] { -2, "Nothomb", "Amelie" });

            migrationBuilder.InsertData(
                table: "livreAuteurs",
                columns: new[] { "AuteurId", "LivreId" },
                values: new object[] { -2, -3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "livreAuteurs",
                keyColumns: new[] { "AuteurId", "LivreId" },
                keyValues: new object[] { -2, -3 });

            migrationBuilder.DeleteData(
                table: "auteurs",
                keyColumn: "AuteurId",
                keyValue: -2);
        }
    }
}
