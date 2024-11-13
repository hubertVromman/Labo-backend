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
        public int Create(Livre l, int[] auteurIds) {
            _dbContext.Add(l);
            _dbContext.SaveChanges();
            foreach (int id in auteurIds)
            {
                _dbContext.Add(new LivreAuteur() {
                    AuteurId = id,
                    LivreId = l.LivreId,
                });
            }
            _dbContext.SaveChanges();
            return l.LivreId;
        }

        public Livre Get(int id) {
            Livre l = _dbContext.livres.Where(l => l.LivreId == id).Include(l => l.LivreAuteur).ThenInclude(la => la.Auteur).Include(l => l.Genre).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
            return l;
        }

        public IEnumerable<Livre> ParAuteur(int id) {
            IEnumerable<Livre> l = _dbContext.livres.Include(l => l.LivreAuteur).ThenInclude(la => la.Auteur).Include(l => l.Genre).Where(l => l.LivreAuteur.Select(la => la.AuteurId).Contains(id));
            return l;
        }

        public IEnumerable<Livre> ParGenre(string genre) {
            IEnumerable<Livre> l = _dbContext.livres.Include(l => l.Genre).Where(l => l.Genre.NomGenre == genre).Include(l => l.LivreAuteur).ThenInclude(la => la.Auteur);
            return l;
        }

        public IEnumerable<Livre> Get() {
            return _dbContext.livres.Include(l => l.Genre);
        }

        public int Update(int id, Livre livre) {
            Livre l = _dbContext.livres.Where(l => l.LivreId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
            l.ISBN = livre.ISBN;
            l.Titre = livre.Titre;
            l.DateParution = livre.DateParution;
            l.GenreId = livre.GenreId;
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
