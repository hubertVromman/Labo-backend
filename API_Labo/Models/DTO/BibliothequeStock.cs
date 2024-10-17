namespace API_Labo.Models.DTO {
    public class BibliothequeStock {
        public int BibliothequeId { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string NumeroTelephone { get; set; }
        public List<StockLivre> StockLivre { get; set; }
    }
}
