using System.ComponentModel.DataAnnotations;

namespace API_Labo.Models.Forms {
    public class LivreForm {

        [Required]
        public int ISBN { get; set; }

        [Required]
        public string Titre { get; set; }

        [Required]
        public DateOnly DateParution { get; set; }

        [Required]
        public string Genre { get; set; }

        public decimal PrixVente { get; set; }
    }
}
