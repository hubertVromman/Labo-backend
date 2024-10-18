using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MaxRefreshTokenExpiration",
                table: "utilisateurs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiration",
                table: "utilisateurs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: -1,
                columns: new[] { "AccessToken", "MaxRefreshTokenExpiration", "RefreshToken", "RefreshTokenExpiration" },
                values: new object[] { null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "utilisateurs");

            migrationBuilder.DropColumn(
                name: "MaxRefreshTokenExpiration",
                table: "utilisateurs");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "utilisateurs");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiration",
                table: "utilisateurs");
        }
    }
}
