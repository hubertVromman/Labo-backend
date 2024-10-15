using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entities {
    public class Livre
    {
        public int LivreId { get; set; }
        public int ISBN { get; set; }
        public string Titre { get; set; }
        public DateOnly DateParution { get; set; }
        public string Genre { get; set; }
        public decimal PrixVente { get; set; }

        public List<LivreAuteur> LivreAuteur { get; set; }
        public List<StockLivre> StockLivre { get; set; }
        public List<PretLivre> PretLivre { get; set; }
        public List<VenteLivre> VenteLivre { get; set; }
    }
}
