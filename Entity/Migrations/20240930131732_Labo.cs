using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "auteurs",
                columns: table => new
                {
                    AuteurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auteurs", x => x.AuteurId);
                });

            migrationBuilder.CreateTable(
                name: "bibliotheques",
                columns: table => new
                {
                    BibliothequeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NumeroTelephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bibliotheques", x => x.BibliothequeId);
                });

            migrationBuilder.CreateTable(
                name: "livres",
                columns: table => new
                {
                    LivreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateParution = table.Column<DateOnly>(type: "date", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrixVente = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livres", x => x.LivreId);
                });

            migrationBuilder.CreateTable(
                name: "utilisateurs",
                columns: table => new
                {
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateurs", x => x.UtilisateurId);
                });

            migrationBuilder.CreateTable(
                name: "livreAuteurs",
                columns: table => new
                {
                    LivreId = table.Column<int>(type: "int", nullable: false),
                    AuteurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livreAuteurs", x => new { x.LivreId, x.AuteurId });
                    table.ForeignKey(
                        name: "FK_LivreAuteur_Auteur",
                        column: x => x.AuteurId,
                        principalTable: "auteurs",
                        principalColumn: "AuteurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivreAuteur_Livre",
                        column: x => x.LivreId,
                        principalTable: "livres",
                        principalColumn: "LivreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stockLivres",
                columns: table => new
                {
                    LivreId = table.Column<int>(type: "int", nullable: false),
                    BibliothequeId = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockLivres", x => new { x.LivreId, x.BibliothequeId });
                    table.ForeignKey(
                        name: "FK_StockLivre_Bibliotheque",
                        column: x => x.BibliothequeId,
                        principalTable: "bibliotheques",
                        principalColumn: "BibliothequeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockLivre_Livre",
                        column: x => x.LivreId,
                        principalTable: "livres",
                        principalColumn: "LivreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emprunts",
                columns: table => new
                {
                    EmpruntId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<DateOnly>(type: "date", nullable: false),
                    DateFin = table.Column<DateOnly>(type: "date", nullable: false),
                    EmprunteurId = table.Column<int>(type: "int", nullable: false),
                    BibliothequeId = table.Column<int>(type: "int", nullable: false)
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
                name: "ventes",
                columns: table => new
                {
                    VenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateVente = table.Column<DateOnly>(type: "date", nullable: false),
                    AcheteurId = table.Column<int>(type: "int", nullable: false),
                    BibliothequeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventes", x => x.VenteId);
                    table.ForeignKey(
                        name: "FK_Vente_Bibliotheque",
                        column: x => x.BibliothequeId,
                        principalTable: "bibliotheques",
                        principalColumn: "BibliothequeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vente_Utilisateur",
                        column: x => x.AcheteurId,
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

            migrationBuilder.CreateTable(
                name: "venteLivres",
                columns: table => new
                {
                    VenteId = table.Column<int>(type: "int", nullable: false),
                    LivreId = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    PrixVente = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venteLivres", x => new { x.VenteId, x.LivreId });
                    table.ForeignKey(
                        name: "FK_VenteLivre_Emprunt",
                        column: x => x.VenteId,
                        principalTable: "ventes",
                        principalColumn: "VenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VenteLivre_Livre",
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

            migrationBuilder.CreateIndex(
                name: "IX_livreAuteurs_AuteurId",
                table: "livreAuteurs",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_livres_ISBN",
                table: "livres",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stockLivres_BibliothequeId",
                table: "stockLivres",
                column: "BibliothequeId");

            migrationBuilder.CreateIndex(
                name: "IX_venteLivres_LivreId",
                table: "venteLivres",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_ventes_AcheteurId",
                table: "ventes",
                column: "AcheteurId");

            migrationBuilder.CreateIndex(
                name: "IX_ventes_BibliothequeId",
                table: "ventes",
                column: "BibliothequeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emprunLivres");

            migrationBuilder.DropTable(
                name: "livreAuteurs");

            migrationBuilder.DropTable(
                name: "stockLivres");

            migrationBuilder.DropTable(
                name: "venteLivres");

            migrationBuilder.DropTable(
                name: "emprunts");

            migrationBuilder.DropTable(
                name: "auteurs");

            migrationBuilder.DropTable(
                name: "ventes");

            migrationBuilder.DropTable(
                name: "livres");

            migrationBuilder.DropTable(
                name: "bibliotheques");

            migrationBuilder.DropTable(
                name: "utilisateurs");
        }
    }
}
