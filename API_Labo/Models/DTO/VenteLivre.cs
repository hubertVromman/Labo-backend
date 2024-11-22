namespace API_Labo.Models.DTO
{
    public class VenteLivre
    {
        public Livre Livre { get; set; }
        public int Quantite { get; set; }
        public decimal? PrixVente { get; set; }
    }
}
