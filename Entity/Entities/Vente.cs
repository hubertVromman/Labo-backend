using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entities {
    public class Vente {
        public int VenteId { get; set; }
        public DateOnly DateVente { get; set; }
        public List<VenteLivre> VenteLivre { get; set; }
        public int AcheteurId { get; set; }
        public Utilisateur Acheteur { get; set; }
        public int BibliothequeId { get; set; }
        public Bibliotheque Bibliotheque { get; set; }
    }
}
