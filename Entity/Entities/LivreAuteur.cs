using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entities {
    public class LivreAuteur {
        public int LivreId { get; set; }
        public Livre Livre { get; set; }
        public int AuteurId { get; set; }
        public Auteur Auteur { get; set; }
    }
}
