﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entities {
    public class Bibliotheque
    {
        public int BibliothequeId { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string NumeroTelephone { get; set; }
        public List<StockLivre> StockLivre { get; set; }
        public List<Pret> Prets { get; set; }
        public List<Vente> Ventes { get; set; }
    }
}
