using BLL_Labo.Entities;
using BLL_Labo.Interfaces;
using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BLL_Labo.Services
{
    public class BibliothequeService(DatabaseContext _dbContext) : IBibliothequeService {
        public int Create(Bibliotheque b) {
            _dbContext.Add(b);
            _dbContext.SaveChanges();
            return b.BibliothequeId;
        }

        public Bibliotheque Get(int id) {
            return _dbContext.bibliotheques.Where(a => a.BibliothequeId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
        }

        public IEnumerable<Bibliotheque> Get() {
            return _dbContext.bibliotheques;
        }

        public int Update(int id, Bibliotheque bibliotheque) {
            Bibliotheque b = _dbContext.bibliotheques.Where(a => a.BibliothequeId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
            b.Nom = bibliotheque.Nom;
            b.Adresse = bibliotheque.Adresse;
            b.NumeroTelephone = bibliotheque.NumeroTelephone;
            return _dbContext.SaveChanges();
        }

        public int Delete(int id) {
            Bibliotheque b = _dbContext.bibliotheques.Where(a => a.BibliothequeId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
            _dbContext.Remove(b);
            return _dbContext.SaveChanges();
        }

        public int AjouterStock(StockForm s, bool enregistrerChangements = true) {
            StockLivre? sl = _dbContext.stockLivres.Where(a => a.BibliothequeId == s.BibliothequeId && a.LivreId == s.LivreId).FirstOrDefault();
            if (sl is not null) {
                sl.StockAchat += s.StockAchat;
                sl.StockLocation += s.StockLocation;
            } else {
                StockLivre newsl = new StockLivre() {
                    LivreId = s.LivreId,
                    BibliothequeId = s.BibliothequeId,
                    StockLocation = s.StockLocation,
                    StockAchat = s.StockAchat,
                };
                _dbContext.Add(newsl);
            }
            if (enregistrerChangements) {
                return _dbContext.SaveChanges();
            }
            return 1;
        }

        public int SetStock(StockForm s) {
            StockLivre? sl = _dbContext.stockLivres.Where(a => a.BibliothequeId == s.BibliothequeId && a.LivreId == s.LivreId).FirstOrDefault();
            if (sl is not null)
            {
                sl.StockAchat = s.StockAchat;
                sl.StockLocation = s.StockLocation;
            }
            else
            {
                StockLivre newsl = new StockLivre()
                {
                    LivreId = s.LivreId,
                    BibliothequeId = s.BibliothequeId,
                    StockLocation = s.StockLocation,
                    StockAchat = s.StockAchat,
                };
                _dbContext.Add(newsl);
            }
            return _dbContext.SaveChanges();
        }

        public int RetirerStock(StockForm s) {
            StockLivre sl = _dbContext.stockLivres.Where(sl => sl.BibliothequeId == s.BibliothequeId && sl.LivreId == s.LivreId).FirstOrDefault() ?? throw new ArgumentException("Stock non trouvé");
            if (s.StockAchat > sl.StockAchat || s.StockLocation > sl.StockLocation)
                throw new ArgumentException("Le stock à retirer excède la quantité présente");
            sl.StockAchat -= s.StockAchat;
            sl.StockLocation -= s.StockLocation;
            return _dbContext.SaveChanges();
        }

        public Bibliotheque AvecStock(int id) {
            return _dbContext.bibliotheques
                .Where(b => b.BibliothequeId == id)
                .Include(b => b.StockLivre)
                .ThenInclude(sl => sl.Livre)
                .ThenInclude(l => l.Genre)
                .FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
        }
    }
}
