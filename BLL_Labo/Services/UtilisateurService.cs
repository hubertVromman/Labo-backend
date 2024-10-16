using BLL_Labo.Interfaces;
using EntityFramework.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Labo.Services
{
    public class UtilisateurService : IUtilisateurService {
        private readonly DatabaseContext _dbContext;

        public UtilisateurService(DatabaseContext ctx) {
            _dbContext = ctx;
        }

        public bool Register(string email, string motDePasse, string nom, string prenom) {
            Utilisateur u = new Utilisateur() {
                Email = email,
                MotDePasse = motDePasse,
                Nom = nom,
                Prenom = prenom
            };
            _dbContext.Add(u);
            _dbContext.SaveChanges();
            return u.UtilisateurId != 0;
        }

        public List<Utilisateur> GetAll() {
            return _dbContext.utilisateurs.ToList();
        }

        public Utilisateur? GetUserByEmail(string email) {
            return _dbContext.utilisateurs.Where(u => u.Email == email).FirstOrDefault();
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
