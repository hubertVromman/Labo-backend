using BLL_Labo.Entities;
using BLL_Labo.Interfaces;
using EntityFramework.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Labo.Services
{
    public class PretService(DatabaseContext _dbContext, IBibliothequeService _bibliothequeService) : IPretService {

        public IEnumerable<Pret> Get() {
            IEnumerable<Pret> prets = _dbContext.prets.Include(v => v.PretLivre).ThenInclude(vl => vl.Livre).Include(v => v.Emprunteur).Include(v => v.Bibliotheque);
            foreach (Pret p in prets) {
                p.Emprunteur.Emprunts = null;
                foreach (PretLivre pretLivre in p.PretLivre) {
                    pretLivre.Pret = null;
                    pretLivre.Livre.PretLivre = null;
                }
                p.Bibliotheque.Prets = null;
            }
            return prets;
        }

        public Pret Get(int id) {
            Pret? p = _dbContext.prets.Where(v => v.PretId == id).Include(v => v.PretLivre).ThenInclude(vl => vl.Livre).Include(v => v.Emprunteur).Include(v => v.Bibliotheque).FirstOrDefault();
            if (p is null)
                throw new IndexOutOfRangeException();
            p.Emprunteur.Emprunts = null;
            foreach (PretLivre pretLivre in p.PretLivre) {
                pretLivre.Pret = null;
                pretLivre.Livre.PretLivre = null;
            }
            p.Bibliotheque.Prets = null;
            return p;
        }

        public int Create(Commande commande) {
            commande.DateCommande = DateOnly.FromDateTime(DateTime.Now);

            if (commande.LivreIdQuantite.Any(l => l.Value <= 0)) {
                throw new Exception("La quantité de chaque livre doit être supérieure à 0");
            }

            IQueryable<StockLivre> stockLivres = _dbContext.stockLivres.Where(sl => commande.LivreIdQuantite.Select(l => l.Key).Contains(sl.LivreId) && sl.BibliothequeId == commande.BibliothequeId);
            if (stockLivres.Count() != commande.LivreIdQuantite.Count()) {
                throw new Exception("Tous les livres n'ont pas été trouvés dans cette bibliothèque");
            }

            foreach (StockLivre sl in stockLivres) {
                if (sl.StockLocation < commande.LivreIdQuantite[sl.LivreId]) {
                    throw new Exception($"Stock insufisant pour le livre {sl.LivreId}: {sl.StockAchat} en stock mais {commande.LivreIdQuantite[sl.LivreId]} demandée");
                }
            }

            Pret p = new Pret() {
                DateDebut = commande.DateCommande,
                DateFin = commande.DateCommande.AddDays(7),
                EmprunteurId = commande.UtilisateurId,
                BibliothequeId = commande.BibliothequeId,
            };

            _dbContext.Add(p);
            _dbContext.SaveChanges();
            foreach (KeyValuePair<int, int> kvp in commande.LivreIdQuantite) {
                _dbContext.Add(new PretLivre() {
                    PretId = p.PretId,
                    LivreId = kvp.Key,
                    Quantite = kvp.Value,
                });
                _dbContext.stockLivres.Where(sl => sl.LivreId == kvp.Key && sl.BibliothequeId == commande.BibliothequeId).FirstOrDefault().StockLocation -= kvp.Value;
            }
            _dbContext.SaveChanges();
            return p.PretId;
        }

        public int Rendre(int id, int utilisateurId) {
            Pret p = _dbContext.prets.Where(p => p.PretId == id).Include(p => p.PretLivre).FirstOrDefault() ?? throw new ArgumentOutOfRangeException("Le pret n'a pas été trouvé");
            if (p.EmprunteurId != utilisateurId) {
                throw new UnauthorizedAccessException("L'utilisateur n'a pas fait le pret");
            }
            foreach (PretLivre pl in p.PretLivre)
            {
                _bibliothequeService.AjouterStock(new StockForm() {
                    BibliothequeId = p.BibliothequeId,
                    LivreId = pl.LivreId,
                    StockLocation = pl.Quantite,
                }, false);
            }
            p.EstRendu = true;
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Pret> ParUtilisateur(int id) {
            IEnumerable<Pret> prets = _dbContext.prets.Where(p => p.EmprunteurId == id).Include(v => v.Emprunteur).Include(v => v.PretLivre).ThenInclude(vl => vl.Livre).Include(v => v.Bibliotheque);
            foreach (Pret p in prets) {
                p.Emprunteur.Emprunts = null;
                foreach (PretLivre pretLivre in p.PretLivre) {
                    pretLivre.Pret = null;
                    pretLivre.Livre.PretLivre = null;
                }
                p.Bibliotheque.Prets = null;
            }
            return prets;
        }
    }
}
