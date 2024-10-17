namespace API_Labo.Models.DTO {
    public class Livre {
        public int LivreId { get; set; }
        public int ISBN { get; set; }
        public string Titre { get; set; }
        public DateOnly DateParution { get; set; }
        public string Genre { get; set; }
        public decimal PrixVente { get; set; }
    }
}
