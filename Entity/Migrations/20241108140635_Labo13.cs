using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "utilisateurs",
                type: "nvarchar(320)",
                maxLength: 320,
                nullable: false,
                defaultValue: "Utilisateur",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: -1,
                column: "MotDePasse",
                value: "숓䯧䙪㾢鹟聽ㄱ碓⣐辩멆﯈幓엍䢕ᑉ䟎繧﵊뚫㝹䬪⭣뱔ᄦ䣩駽");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "utilisateurs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(320)",
                oldMaxLength: 320,
                oldDefaultValue: "Utilisateur");

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: -1,
                column: "MotDePasse",
                value: "3aJ7NUldI5y7r3eiOP2BEC87BGaV41jrDL4E8/wWydFgSYVEhPbI2WalHlfEdXXHzxVtBQYnkK/J/tCaAizsbg==");
        }
    }
}
