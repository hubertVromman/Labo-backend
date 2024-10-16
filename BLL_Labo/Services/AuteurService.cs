using BLL_Labo.Interfaces;
using EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Labo.Services
{
    public class AuteurService(DatabaseContext _dbContext) : IAuteurService {
        public int? Create(Auteur a) {
            _dbContext.Add(a);
            _dbContext.SaveChanges();
            return a.AuteurId;
        }

        public Auteur Get(int id) {
            return _dbContext.auteurs.Where(a => a.AuteurId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
        }

        public IEnumerable<Auteur> Get() {
            return _dbContext.auteurs;
        }

        public int Update(int id, Auteur auteur) {
            Auteur a = _dbContext.auteurs.Where(a => a.AuteurId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
            a.Nom = auteur.Nom;
            a.Prenom = auteur.Prenom;
            _dbContext.SaveChanges();
            return 1;
        }

        public int Delete(int id) {
            Auteur a = _dbContext.auteurs.Where(a => a.AuteurId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
            _dbContext.Remove(a);
            _dbContext.SaveChanges();
            return 1;
        }
    }
}
