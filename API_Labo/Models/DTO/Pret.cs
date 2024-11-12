namespace API_Labo.Models.DTO
{
    public class Pret
    {
        public int PretId { get; set; }
        public DateOnly DateDebut { get; set; }
        public DateOnly DateFin { get; set; }
        public List<PretLivre> PretLivre { get; set; }
        public bool EstRendu { get; set; } = false;
        public Utilisateur Emprunteur { get; set; }
        public Bibliotheque Bibliotheque { get; set; }
    }
}
