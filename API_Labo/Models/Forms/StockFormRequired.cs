using System.ComponentModel.DataAnnotations;

namespace API_Labo.Models.Forms {
    public class StockFormRequired {

        [Required]
        public int? BibliothequeId { get; set; }

        [Required]
        public int? LivreId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La valeur du StockLocation doit etre plus grande que 0")]
        public int? StockLocation { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La valeur du StockAchat doit etre plus grande que 0")]
        public int? StockAchat { get; set; }
    }
}
