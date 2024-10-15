using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "auteurs",
                columns: new[] { "AuteurId", "Nom", "Prenom" },
                values: new object[] { -1, "Durant", "Pierre" });

            migrationBuilder.InsertData(
                table: "livres",
                columns: new[] { "LivreId", "DateParution", "Genre", "ISBN", "PrixVente", "Titre" },
                values: new object[,]
                {
                    { -3, new DateOnly(2015, 10, 25), "Porno", 1236, 19.99m, "Coup de fouet" },
                    { -2, new DateOnly(2015, 10, 25), "Romantique", 1235, 19.99m, "Coup de foudre" },
                    { -1, new DateOnly(2015, 10, 25), "Thriller", 1234, 19.99m, "Coup de feu" }
                });

            migrationBuilder.InsertData(
                table: "utilisateurs",
                columns: new[] { "UtilisateurId", "Email", "MotDePasse", "Nom", "Prenom" },
                values: new object[] { -1, "Hello@gmail.com", "1234", "Noel", "Benjamin" });

            migrationBuilder.InsertData(
                table: "livreAuteurs",
                columns: new[] { "AuteurId", "LivreId" },
                values: new object[,]
                {
                    { -1, -3 },
                    { -1, -2 },
                    { -1, -1 }
                });

            migrationBuilder.InsertData(
                table: "stockLivres",
                columns: new[] { "BibliothequeId", "LivreId", "StockAchat", "StockLocation" },
                values: new object[,]
                {
                    { -1, -3, 10, 10 },
                    { -1, -2, 10, 10 },
                    { -1, -1, 10, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "livreAuteurs",
                keyColumns: new[] { "AuteurId", "LivreId" },
                keyValues: new object[] { -1, -3 });

            migrationBuilder.DeleteData(
                table: "livreAuteurs",
                keyColumns: new[] { "AuteurId", "LivreId" },
                keyValues: new object[] { -1, -2 });

            migrationBuilder.DeleteData(
                table: "livreAuteurs",
                keyColumns: new[] { "AuteurId", "LivreId" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.DeleteData(
                table: "stockLivres",
                keyColumns: new[] { "BibliothequeId", "LivreId" },
                keyValues: new object[] { -1, -3 });

            migrationBuilder.DeleteData(
                table: "stockLivres",
                keyColumns: new[] { "BibliothequeId", "LivreId" },
                keyValues: new object[] { -1, -2 });

            migrationBuilder.DeleteData(
                table: "stockLivres",
                keyColumns: new[] { "BibliothequeId", "LivreId" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.DeleteData(
                table: "utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "auteurs",
                keyColumn: "AuteurId",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -1);
        }
    }
}
