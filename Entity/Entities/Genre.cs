using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entities {
    public class Genre {
        public int GenreId { get; set; }
        public string NomGenre { get; set; }
        public List<Livre> Livres { get; set; }
    }
}
