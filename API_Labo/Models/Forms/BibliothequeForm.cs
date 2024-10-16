using System.ComponentModel.DataAnnotations;

namespace API_Labo.Models.Forms {
    public class BibliothequeForm {

        [Required]
        public string Nom { get; set; }

        public string Adresse { get; set; }

        public string NumeroTelephone { get; set; }
    }
}
