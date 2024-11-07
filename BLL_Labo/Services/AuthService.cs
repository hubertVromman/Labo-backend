using BLL_Labo.Entities;
using EntityFramework.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Labo.Services {
    public class AuthService(DatabaseContext _dbContext) {
        public static readonly string secretKey =
            "La Saint-Nicolas c'est le 6 décembre et Noël c'est le 25 décembre";

        public string GenerateAccessToken(Utilisateur u) {
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
                expires: DateTime.UtcNow.AddSeconds(3),
                issuer: "monapi.com"
            );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

        public string GenerateRefreshToken() {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public Token GenerateTokensFromUser(Utilisateur u, bool updateExpiration = true) {
            Token t = new Token() {
                AccessToken = GenerateAccessToken(u),
                RefreshToken = GenerateRefreshToken(),
            };
            u.AccessToken = t.AccessToken;
            u.RefreshToken = t.RefreshToken;
            u.RefreshTokenExpiration = DateTime.Now.AddHours(3);
            if (updateExpiration)
                u.MaxRefreshTokenExpiration = DateTime.Now.AddDays(7);

            if (u.RefreshTokenExpiration > u.MaxRefreshTokenExpiration)
                u.RefreshTokenExpiration = u.MaxRefreshTokenExpiration;

            _dbContext.SaveChanges();
            return t;
        }

        public Token RefreshToken(Token t) {
            Utilisateur u = _dbContext.utilisateurs
                .Where(u => u.RefreshToken == t.RefreshToken && u.AccessToken == t.AccessToken && u.RefreshTokenExpiration > DateTime.Now)
                .FirstOrDefault() 
                ?? throw new Exception("Token non valide ou expiré");
            return GenerateTokensFromUser(u, false);
        }
    }
}
