namespace EntityFramework.Entities {
    public class Utilisateur
    {
        public int UtilisateurId { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Role { get; set; } = "Utilisateur";
        public List<Pret> Emprunts { get; set; }
        public List<Vente> Achats { get; set; }
    }
}
