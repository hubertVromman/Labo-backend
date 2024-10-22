using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: -1,
                column: "MotDePasse",
                value: "3aJ7NUldI5y7r3eiOP2BEC87BGaV41jrDL4E8/wWydFgSYVEhPbI2WalHlfEdXXHzxVtBQYnkK/J/tCaAizsbg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: -1,
                column: "MotDePasse",
                value: "$2a$11$8AaJxUgo7ifbZZHsrVEn5O/jRhcYvAvZqfSkHf29IDDAqw//7p346");
        }
    }
}
