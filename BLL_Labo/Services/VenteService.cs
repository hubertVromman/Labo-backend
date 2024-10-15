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

namespace BLL_Labo.Services {
    public class VenteService : IVenteService {

        private DatabaseContext _dbContext;

        public VenteService(DatabaseContext db) {
            _dbContext = db;
        }

        public IEnumerable<Vente> Get() {
            IEnumerable<Vente> ventes = _dbContext.ventes.Include(v => v.VenteLivre).ThenInclude(vl => vl.Livre).Include(v => v.Acheteur).Include(v => v.Bibliotheque);
            foreach (Vente v in ventes) {
                v.Acheteur.Achats = null;
                foreach (VenteLivre venteLivre in v.VenteLivre) {
                    venteLivre.Vente = null;
                    venteLivre.Livre.VenteLivre = null;
                }
                v.Bibliotheque.Ventes = null;
            }
            return ventes;
        }

        public Vente? Get(int id) {
            Vente? v = _dbContext.ventes.Where(v => v.VenteId == id).Include(v => v.VenteLivre).ThenInclude(vl => vl.Livre).Include(v => v.Acheteur).Include(v => v.Bibliotheque).FirstOrDefault();
            if (v is null)
                throw new IndexOutOfRangeException();
            v.Acheteur.Achats = null;
            foreach (VenteLivre venteLivre in v.VenteLivre)
            {
                venteLivre.Vente = null;
                venteLivre.Livre.VenteLivre = null;
            }
            v.Bibliotheque.Ventes = null;
            return v;
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
                if (sl.StockAchat < commande.LivreIdQuantite[sl.LivreId]) {
                    throw new Exception($"Stock insufisant pour le livre {sl.LivreId}: {sl.StockAchat} en stock mais {commande.LivreIdQuantite[sl.LivreId]} demandée");
                }
            }

            Vente v = new Vente() {
                DateVente = commande.DateCommande,
                AcheteurId = commande.UtilisateurId,
                BibliothequeId = commande.BibliothequeId,
            };

            _dbContext.Add(v);
            _dbContext.SaveChanges();
            foreach (KeyValuePair<int, int> kvp in commande.LivreIdQuantite) {
                _dbContext.Add(new VenteLivre() {
                    VenteId = v.VenteId,
                    LivreId = kvp.Key,
                    Quantite = kvp.Value,
                    PrixVente = _dbContext.livres.Where(l => l.LivreId == kvp.Key).FirstOrDefault().PrixVente,
                });
                _dbContext.stockLivres.Where(sl => sl.LivreId == kvp.Key && sl.BibliothequeId == commande.BibliothequeId).FirstOrDefault().StockAchat -= kvp.Value;
            }
            _dbContext.SaveChanges();
            return v.VenteId;
        }
    }
}
