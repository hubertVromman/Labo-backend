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
                //UtilisateurId = commande.UtilisateurId,
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
    }
}
