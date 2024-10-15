using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entities {
    public class Auteur {
        public int AuteurId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public List<LivreAuteur> LivreAuteur { get; set; }

    }
}
