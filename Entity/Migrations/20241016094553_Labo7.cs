using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: -1,
                column: "Role",
                value: "Admin");

            migrationBuilder.CreateIndex(
                name: "IX_utilisateurs_Email",
                table: "utilisateurs",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_utilisateurs_Email",
                table: "utilisateurs");

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: -1,
                column: "Role",
                value: "Utilisateur");
        }
    }
}
