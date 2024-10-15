using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Labo.Entities {
    public class Commande {
        public Dictionary<int, int> LivreIdQuantite { get; set; }
        public int UtilisateurId { get; set; }
        public int BibliothequeId { get; set; }
        public DateOnly DateCommande { get; set; }
    }
}
