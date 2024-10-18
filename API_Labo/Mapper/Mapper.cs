using API_Labo.Models.DTO;
using API_Labo.Models.Forms;
using BLL = BLL_Labo.Entities;
using Entity = EntityFramework.Entities;

namespace API_Labo.Mapper
{
    public static class Mapper {
        public static BLL.Commande ToBLL(this Commande commande) {
            return new BLL.Commande() {
                LivreIdQuantite = commande.LivreIdQuantite,
                BibliothequeId = commande.BibliothequeId,
            };
        }

        public static Entity.Auteur ToEntity(this AuteurForm a) {
            return new Entity.Auteur() {
                Nom = a.Nom,
                Prenom = a.Prenom,
            };
        }

        public static Entity.Bibliotheque ToEntity(this BibliothequeForm a) {
            return new Entity.Bibliotheque() {
                Nom = a.Nom,
                Adresse = a.Adresse,
                NumeroTelephone = a.NumeroTelephone,
            };
        }

        public static BLL.StockForm ToBLL(this StockForm s) {
            return new BLL.StockForm() {
                LivreId = s.LivreId,
                BibliothequeId = s.BibliothequeId,
                StockAchat = s.StockAchat,
                StockLocation = s.StockLocation,
            };
        }

        public static BLL.StockForm ToBLL(this StockFormRequired s) {
            return new BLL.StockForm() {
                LivreId = s.LivreId,
                BibliothequeId = s.BibliothequeId,
                StockAchat = s.StockAchat,
                StockLocation = s.StockLocation,
            };
        }

        public static Entity.Livre ToEntity(this LivreForm l) {
            return new Entity.Livre() {
                ISBN = l.ISBN,
                Titre = l.Titre,
                DateParution = l.DateParution,
                Genre = l.Genre,
                PrixVente = l.PrixVente,
            };
        }

        public static BLL.Token ToBLL(this TokenForm t) {
            return new BLL.Token() {
                AccessToken = t.AccessToken,
                RefreshToken = t.RefreshToken,
            };
        }

        public static Livre ToLivre(this Entity.Livre l) {
            return new Livre() {
                LivreId = l.LivreId,
                ISBN = l.ISBN,
                Titre = l.Titre,
                DateParution = l.DateParution,
                Genre = l.Genre,
                PrixVente = l.PrixVente,
            };
        }

        public static LivreDetails ToLivreDetails(this Entity.Livre l) {
            return new LivreDetails() {
                LivreId = l.LivreId,
                ISBN = l.ISBN,
                Titre = l.Titre,
                DateParution = l.DateParution,
                Genre = l.Genre,
                PrixVente = l.PrixVente,
                Auteurs = l.LivreAuteur.Select(la => la.Auteur.ToAuteur()).ToList(),
            };
        }

        public static Auteur ToAuteur(this Entity.Auteur a) {
            return new Auteur() {
                AuteurId = a.AuteurId,
                Nom = a.Nom,
                Prenom = a.Prenom,
            };
        }

        public static AuteurDetails ToAuteurDetails(this Entity.Auteur a) {
            return new AuteurDetails() {
                AuteurId = a.AuteurId,
                Nom = a.Nom,
                Prenom = a.Prenom,
                Livres = a.LivreAuteur.Select(la => la.Livre.ToLivre()).ToList(),
            };
        }

        public static Bibliotheque ToBibliotheque(this Entity.Bibliotheque b) {
            return new Bibliotheque() {
                BibliothequeId = b.BibliothequeId,
                Nom = b.Nom,
                Adresse = b.Adresse,
                NumeroTelephone = b.NumeroTelephone,
            };
        }

        public static BibliothequeStock ToBibliothequeStock(this Entity.Bibliotheque b) {
            return new BibliothequeStock() {
                BibliothequeId = b.BibliothequeId,
                Nom = b.Nom,
                Adresse = b.Adresse,
                NumeroTelephone = b.NumeroTelephone,
                StockLivre = b.StockLivre.Select(sl => sl.ToStockLivre()).ToList(),
            };
        }

        public static StockLivre ToStockLivre(this Entity.StockLivre sl) {
            return new StockLivre() {
                Livre = sl.Livre.ToLivre(),
                StockLocation = sl.StockLocation,
                StockAchat = sl.StockAchat,
            };
        }

        public static Utilisateur ToUtilisateur(this Entity.Utilisateur u) {
            return new Utilisateur() {
                UtilisateurId = u.UtilisateurId,
                Email = u.Email,
                Nom = u.Nom,
                Prenom = u.Prenom,
                Role = u.Role,
            };
        }
    }
}
