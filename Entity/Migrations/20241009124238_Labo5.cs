using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpruntLivre_Emprunt",
                table: "emprunLivres");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpruntLivre_Livre",
                table: "emprunLivres");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprunt_Bibliotheque",
                table: "emprunts");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprunt_Utilisateur",
                table: "emprunts");

            migrationBuilder.RenameColumn(
                name: "EmpruntId",
                table: "emprunts",
                newName: "PretId");

            migrationBuilder.RenameColumn(
                name: "EmpruntId",
                table: "emprunLivres",
                newName: "PretId");

            migrationBuilder.AddForeignKey(
                name: "FK_PretLivre_Livre",
                table: "emprunLivres",
                column: "LivreId",
                principalTable: "livres",
                principalColumn: "LivreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PretLivre_Pret",
                table: "emprunLivres",
                column: "PretId",
                principalTable: "emprunts",
                principalColumn: "PretId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pret_Bibliotheque",
                table: "emprunts",
                column: "BibliothequeId",
                principalTable: "bibliotheques",
                principalColumn: "BibliothequeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pret_Utilisateur",
                table: "emprunts",
                column: "EmprunteurId",
                principalTable: "utilisateurs",
                principalColumn: "UtilisateurId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PretLivre_Livre",
                table: "emprunLivres");

            migrationBuilder.DropForeignKey(
                name: "FK_PretLivre_Pret",
                table: "emprunLivres");

            migrationBuilder.DropForeignKey(
                name: "FK_Pret_Bibliotheque",
                table: "emprunts");

            migrationBuilder.DropForeignKey(
                name: "FK_Pret_Utilisateur",
                table: "emprunts");

            migrationBuilder.RenameColumn(
                name: "PretId",
                table: "emprunts",
                newName: "EmpruntId");

            migrationBuilder.RenameColumn(
                name: "PretId",
                table: "emprunLivres",
                newName: "EmpruntId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpruntLivre_Emprunt",
                table: "emprunLivres",
                column: "EmpruntId",
                principalTable: "emprunts",
                principalColumn: "EmpruntId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpruntLivre_Livre",
                table: "emprunLivres",
                column: "LivreId",
                principalTable: "livres",
                principalColumn: "LivreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunt_Bibliotheque",
                table: "emprunts",
                column: "BibliothequeId",
                principalTable: "bibliotheques",
                principalColumn: "BibliothequeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprunt_Utilisateur",
                table: "emprunts",
                column: "EmprunteurId",
                principalTable: "utilisateurs",
                principalColumn: "UtilisateurId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
