namespace API_Labo.Models.DTO
{
    public class Commande
    {
        public Dictionary<int, int> LivreIdQuantite { get; set; }
        public int UtilisateurId { get; set; }
        public int BibliothequeId { get; set; }
    }
}
