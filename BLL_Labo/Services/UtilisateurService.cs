using BLL_Labo.Interfaces;
using Dapper;
using EntityFramework.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Labo.Services
{
    public class UtilisateurService : IUtilisateurService {
        private readonly DatabaseContext _dbContext;
        private readonly SqlConnection _connection;

        public UtilisateurService(DatabaseContext ctx, SqlConnection connection) {
            _dbContext = ctx;
            _connection = connection;
        }

        public bool Register(string email, string motDePasse, string nom, string prenom) {
            Utilisateur u = new Utilisateur() {
                Email = email,
                MotDePasse = motDePasse.HashTo64(),
                Nom = nom,
                Prenom = prenom
            };
            _dbContext.Add(u);
            _dbContext.SaveChanges();
            return u.UtilisateurId != 0;
        }

        public Utilisateur Login(string email, string motDePasse) {
            return _connection.QuerySingleOrDefault<Utilisateur>(
                    "Login", 
                    new { email, motDePasse = motDePasse.HashTo64() }, 
                    commandType: CommandType.StoredProcedure
                )
                ?? throw new ArgumentException();
            //return _dbContext.utilisateurs.Where(u => u.Email == email && u.MotDePasse == motDePasse.HashTo64()).FirstOrDefault() ?? throw new ArgumentException();
        }

        public IEnumerable<Utilisateur> GetAll() {
            return _dbContext.utilisateurs;
        }

        public Utilisateur GetUserByEmail(string email) {
            return _dbContext.utilisateurs.Where(u => u.Email == email).FirstOrDefault() ?? throw new ArgumentException();
        }

        public int ChangeRole(int id, string nouveauRole) {
            Utilisateur u = _dbContext.utilisateurs.Where(u => u.UtilisateurId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
            string[] roles = ["Utilisateur", "Employee", "Admin"];
            if (!roles.Contains(nouveauRole)) {
                throw new ArgumentException("Role not found");
            }
            u.Role = nouveauRole;
            return _dbContext.SaveChanges();
        }
    }
}
