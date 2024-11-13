using System.ComponentModel.DataAnnotations;

namespace API_Labo.Models.Forms {
    public class GenreForm {
        [Required]
        public string NomGenre { get; set; }
    }
}
