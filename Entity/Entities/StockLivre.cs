using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entities {
    public class StockLivre {
        public int LivreId { get; set; }
        public Livre Livre { get; set; }
        public int BibliothequeId { get; set; }
        public Bibliotheque Bibliotheque { get; set; }
        public int StockLocation { get; set; }
        public int StockAchat { get; set; }
    }
}
