using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_livres_ISBN",
                table: "livres");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "livres",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_livres_ISBN",
                table: "livres",
                column: "ISBN",
                unique: true,
                filter: "[ISBN] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_livres_ISBN",
                table: "livres");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "livres",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_livres_ISBN",
                table: "livres",
                column: "ISBN",
                unique: true);
        }
    }
}
