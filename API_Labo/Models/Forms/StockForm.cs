using System.ComponentModel.DataAnnotations;

namespace API_Labo.Models.Forms {
    public class StockForm {

        [Required]
        public int BibliothequeId { get; set; }

        [Required]
        public int LivreId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La valeur du StockLocation doit etre plus grande que {0}")]
        public int StockLocation { get; set; } = 0;

        [Range(0, int.MaxValue, ErrorMessage = "La valeur du StockAchat doit etre plus grande que {0}")]
        public int StockAchat { get; set; } = 0;
    }
}
