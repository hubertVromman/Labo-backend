namespace API_Labo.Models.DTO {
    public class Genre {
        public int GenreId { get; set; }
        public string NomGenre { get; set; }
        public List<Livre> Livres { get; set; }
    }
}
