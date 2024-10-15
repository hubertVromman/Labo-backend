using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entities {
    public class Pret
    {
        public int PretId { get; set; }
        public DateOnly DateDebut { get; set; }
        public DateOnly DateFin { get; set; }
        public List<PretLivre> PretLivre { get; set; }
        public int EmprunteurId { get; set; }
        public Utilisateur Emprunteur { get; set; }
        public int BibliothequeId { get; set; }
        public Bibliotheque Bibliotheque { get; set; }
    }
}
