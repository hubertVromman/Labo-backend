using API_Labo.Models.DTO;
using BLL = BLL_Labo.Entities;

namespace API_Labo.Mapper
{
    public static class Mapper {
        public static BLL.Commande ToBLL(this Commande commande) {
            return new BLL.Commande() {
                LivreIdQuantite = commande.LivreIdQuantite,
                BibliothequeId = commande.BibliothequeId,
                UtilisateurId = commande.UtilisateurId,
            };
        }
    }
}
