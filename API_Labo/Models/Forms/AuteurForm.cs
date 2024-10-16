using System.ComponentModel.DataAnnotations;

namespace API_Labo.Models.Forms {
    public class AuteurForm {

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }
    }
}
