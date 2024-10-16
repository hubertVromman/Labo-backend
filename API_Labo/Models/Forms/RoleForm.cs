using System.ComponentModel.DataAnnotations;

namespace API_Labo.Models.Forms {
    public class RoleForm {

        [Required]
        public string Role { get; set; }
    }
}
