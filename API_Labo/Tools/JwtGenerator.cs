using EntityFramework.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Labo.Tools {
    public class JwtGenerator {
        public static readonly string secretKey =
            "La Saint-Nicolas c'est le 6 décembre et Noël c'est le 25 décembre";

        public string GenerateToken(Utilisateur u) {
            //Génération de la signin key
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //Génération du payload (Body)
            Claim[] myclaims =
            {
                new Claim(ClaimTypes.NameIdentifier, u.UtilisateurId.ToString()),
                new Claim(ClaimTypes.Email, u.Email),
                new Claim(ClaimTypes.Role, u.Role),
                new Claim(ClaimTypes.Name, u.Nom),
                new Claim(ClaimTypes.GivenName, u.Prenom),
            };

            //Génération du token

            JwtSecurityToken token = new JwtSecurityToken(
                claims: myclaims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddHours(1),
                issuer: "monapi.com"
            );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }
    }
}
