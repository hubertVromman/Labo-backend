using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Labo14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE PROCEDURE [dbo].[Login] @Email                     NVARCHAR (320),    @MotDePasse                NVARCHAR (320) AS BEGIN SELECT * FROM utilisateurs WHERE Email = @Email AND MotDePasse = HASHBYTES('SHA2_512', @MotDePasse); END");
            migrationBuilder.Sql("CREATE PROCEDURE [dbo].[Register] @email NVARCHAR(320), @motDePasse NVARCHAR(320), @nom NVARCHAR(320), @prenom NVARCHAR(320) AS BEGIN INSERT INTO utilisateurs (email, motDePasse, nom, prenom) VALUES (@email, HASHBYTES('SHA2_512', @motDePasse), @nom, @prenom); END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
