namespace API_Labo.Models.DTO {
    public class AuteurDetails {
        public int AuteurId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<Livre> Livres { get; set; }
    }
}
