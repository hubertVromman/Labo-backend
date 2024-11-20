using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "livres",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -3,
                column: "ISBN",
                value: "1236");

            migrationBuilder.UpdateData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -2,
                column: "ISBN",
                value: "1235");

            migrationBuilder.UpdateData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -1,
                column: "ISBN",
                value: "1234");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ISBN",
                table: "livres",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -3,
                column: "ISBN",
                value: 1236);

            migrationBuilder.UpdateData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -2,
                column: "ISBN",
                value: 1235);

            migrationBuilder.UpdateData(
                table: "livres",
                keyColumn: "LivreId",
                keyValue: -1,
                column: "ISBN",
                value: 1234);
        }
    }
}
