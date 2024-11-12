namespace API_Labo.Models.DTO
{
    public class Vente
    {
        public int VenteId { get; set; }
        public DateOnly DateVente { get; set; }
        public List<VenteLivre> VenteLivre { get; set; }
        public Utilisateur Acheteur { get; set; }
        public Bibliotheque Bibliotheque { get; set; }
    }
}
