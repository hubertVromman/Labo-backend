using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entities {
    public class PretLivre {
        public int PretId { get; set; }
        public Pret Pret { get; set; }
        public int LivreId { get; set; }
        public Livre Livre { get; set; }
        public int Quantite { get; set; }
    }
}
