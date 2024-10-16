using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Labo.Entities {
    public class StockForm {

        public int BibliothequeId { get; set; }

        public int LivreId { get; set; }

        public int StockLocation { get; set; } = 0;

        public int StockAchat { get; set; } = 0;
    }
}
