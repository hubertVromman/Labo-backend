using System.ComponentModel.DataAnnotations;

namespace API_Labo.Models.Forms {
    public class Commande
    {

        [Required]
        public Dictionary<int, int> LivreIdQuantite { get; set; }
        //public int UtilisateurId { get; set; }

        [Required]
        public int BibliothequeId { get; set; }
    }
}
