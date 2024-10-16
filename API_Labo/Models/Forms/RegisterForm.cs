using System.ComponentModel.DataAnnotations;

namespace API_Labo.Models.Forms {
    public class RegisterForm {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string MotDePasse { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }
    }
}
