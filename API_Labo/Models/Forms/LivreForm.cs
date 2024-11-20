using System.ComponentModel.DataAnnotations;

namespace API_Labo.Models.Forms {
    public class LivreForm {

        public string ISBN { get; set; }

        [Required]
        public string Titre { get; set; }

        [Required]
        public DateOnly DateParution { get; set; }

        [Required]
        public int GenreId { get; set; }

        public decimal PrixVente { get; set; }

        public List<int> AuteursId { get; set; }
    }
}
