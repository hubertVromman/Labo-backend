using System.ComponentModel.DataAnnotations;

namespace API_Labo.Models.Forms {
    public class LoginForm {

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string MotDePasse { get; set; }
    }
}
