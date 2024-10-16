using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emprunLivres");

            migrationBuilder.DropTable(
                name: "emprunts");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "stockLivres",
                newName: "StockLocation");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "utilisateurs",
                type: "nvarchar(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "utilisateurs",
                type: "nvarchar(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MotDePasse",
                table: "utilisateurs",
                type: "nvarchar(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "utilisateurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StockAchat",
                table: "stockLivres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "prets",
                columns: table => new
                {
                    PretId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<DateOnly>(type: "date", nullable: false),
                    DateFin = table.Column<DateOnly>(type: "date", nullable: false),
                    EmprunteurId = table.Column<int>(type: "int", nullable: false),
                    BibliothequeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prets", x => x.PretId);
                    table.ForeignKey(
                        name: "FK_Pret_Bibliotheque",
                        column: x => x.BibliothequeId,
                        principalTable: "bibliotheques",
                        principalColumn: "BibliothequeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pret_Utilisateur",
                        column: x => x.EmprunteurId,
                        principalTable: "utilisateurs",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pretsLivres",
                columns: table => new
                {
                    PretId = table.Column<int>(type: "int", nullable: false),
                    LivreId = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pretsLivres", x => new { x.PretId, x.LivreId });
                    table.ForeignKey(
                        name: "FK_PretLivre_Livre",
                        column: x => x.LivreId,
                        principalTable: "livres",
                        principalColumn: "LivreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PretLivre_Pret",
                        column: x => x.PretId,
                        principalTable: "prets",
                        principalColumn: "PretId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "auteurs",
                columns: new[] { "AuteurId", "Nom", "Prenom" },
                values: new object[] { -1, "Durant", "Pierre" });

            migrationBuilder.InsertData(
                table: "bibliotheques",
                columns: new[] { "BibliothequeId", "Adresse", "Nom", "NumeroTelephone" },
                values: new object[] { -1, "Rue du Paradis, 5 1400 Nivelles", "Librairie Georges", "+32 68 36 72 98" });

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
                columns: new[] { "UtilisateurId", "Email", "MotDePasse", "Nom", "Prenom", "Role" },
                values: new object[] { -1, "hello@gmail.com", "$2a$11$8AaJxUgo7ifbZZHsrVEn5O/jRhcYvAvZqfSkHf29IDDAqw//7p346", "Noel", "Benjamin", "Utilisateur" });

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

            migrationBuilder.CreateIndex(
                name: "IX_prets_BibliothequeId",
                table: "prets",
                column: "BibliothequeId");

            migrationBuilder.CreateIndex(
                name: "IX_prets_EmprunteurId",
                table: "prets",
                column: "EmprunteurId");

            migrationBuilder.CreateIndex(
                name: "IX_pretsLivres_LivreId",
                table: "pretsLivres",
                column: "LivreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pretsLivres");

            migrationBuilder.DropTable(
                name: "prets");

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
                table: "bibliotheques",
                keyColumn: "BibliothequeId",
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

            migrationBuilder.DropColumn(
                name: "Role",
                table: "utilisateurs");

            migrationBuilder.DropColumn(
                name: "StockAchat",
                table: "stockLivres");

            migrationBuilder.RenameColumn(
                name: "StockLocation",
                table: "stockLivres",
                newName: "Quantite");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "utilisateurs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(320)",
                oldMaxLength: 320);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "utilisateurs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(320)",
                oldMaxLength: 320);

            migrationBuilder.AlterColumn<string>(
                name: "MotDePasse",
                table: "utilisateurs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(320)",
                oldMaxLength: 320);

            migrationBuilder.CreateTable(
                name: "emprunts",
                columns: table => new
                {
                    EmpruntId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BibliothequeId = table.Column<int>(type: "int", nullable: false),
                    EmprunteurId = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateOnly>(type: "date", nullable: false),
                    DateFin = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emprunts", x => x.EmpruntId);
                    table.ForeignKey(
                        name: "FK_Emprunt_Bibliotheque",
                        column: x => x.BibliothequeId,
                        principalTable: "bibliotheques",
                        principalColumn: "BibliothequeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprunt_Utilisateur",
                        column: x => x.EmprunteurId,
                        principalTable: "utilisateurs",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emprunLivres",
                columns: table => new
                {
                    EmpruntId = table.Column<int>(type: "int", nullable: false),
                    LivreId = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emprunLivres", x => new { x.EmpruntId, x.LivreId });
                    table.ForeignKey(
                        name: "FK_EmpruntLivre_Emprunt",
                        column: x => x.EmpruntId,
                        principalTable: "emprunts",
                        principalColumn: "EmpruntId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpruntLivre_Livre",
                        column: x => x.LivreId,
                        principalTable: "livres",
                        principalColumn: "LivreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_emprunLivres_LivreId",
                table: "emprunLivres",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_emprunts_BibliothequeId",
                table: "emprunts",
                column: "BibliothequeId");

            migrationBuilder.CreateIndex(
                name: "IX_emprunts_EmprunteurId",
                table: "emprunts",
                column: "EmprunteurId");
        }
    }
}
