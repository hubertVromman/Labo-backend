using BLL_Labo.Interfaces;
using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Labo.Services
{
    public class LivreService(DatabaseContext _dbContext) : ILivreService {
        public int? Create(Livre l) {
            _dbContext.Add(l);
            _dbContext.SaveChanges();
            return l.LivreId;
        }

        public Livre Get(int id) {
            return _dbContext.livres.Where(l => l.LivreId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
        }

        public IEnumerable<Livre> Get() {
            return _dbContext.livres;
        }

        public int Update(int id, Livre livre) {
            Livre l = _dbContext.livres.Where(l => l.LivreId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
            l.ISBN = livre.ISBN;
            l.Titre = livre.Titre;
            l.DateParution = livre.DateParution;
            l.Genre = livre.Genre;
            l.PrixVente = livre.PrixVente;
            return _dbContext.SaveChanges();
        }

        public int Delete(int id) {
            Livre l = _dbContext.livres.Where(l => l.LivreId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
            _dbContext.Remove(l);
            return _dbContext.SaveChanges();
        }
    }
}
