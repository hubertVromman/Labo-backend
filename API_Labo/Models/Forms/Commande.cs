namespace API_Labo.Models.Forms {
    public class Commande
    {
        public Dictionary<int, int> LivreIdQuantite { get; set; }
        //public int UtilisateurId { get; set; }
        public int BibliothequeId { get; set; }
    }
}
