using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "stockLivres",
                newName: "StockLocation");

            migrationBuilder.AddColumn<int>(
                name: "StockAchat",
                table: "stockLivres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "bibliotheques",
                columns: new[] { "BibliothequeId", "Adresse", "Nom", "NumeroTelephone" },
                values: new object[] { -1, "Rue du Paradis, 5 1400 Nivelles", "Librairie Georges", "+32 68 36 72 98" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bibliotheques",
                keyColumn: "BibliothequeId",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "StockAchat",
                table: "stockLivres");

            migrationBuilder.RenameColumn(
                name: "StockLocation",
                table: "stockLivres",
                newName: "Quantite");
        }
    }
}
