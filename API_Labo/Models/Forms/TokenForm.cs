using System.ComponentModel.DataAnnotations;

namespace API_Labo.Models.Forms {
    public class TokenForm {

        [Required]
        public string AccessToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
