namespace API_Labo.Models.DTO {
    public class LivreDetails {
        public int LivreId { get; set; }
        public string ISBN { get; set; }
        public string Titre { get; set; }
        public DateOnly DateParution { get; set; }
        public string Genre { get; set; }
        public decimal PrixVente { get; set; }
        public List<Auteur> Auteurs { get; set; }
    }
}
