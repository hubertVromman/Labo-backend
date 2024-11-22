using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entities {
    public class VenteLivre {
        public int VenteId { get; set; }
        public Vente Vente { get; set; }
        public int LivreId { get; set; }
        public Livre Livre { get; set; }
        public int Quantite { get; set; }
        public decimal? PrixVente { get; set; }
    }
}
