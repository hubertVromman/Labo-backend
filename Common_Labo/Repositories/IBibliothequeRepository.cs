using Common_Labo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Labo.Repositories {
    public interface IBibliothequeRepository<TBibliotheque> : ICRUDRepository<TBibliotheque, int> where TBibliotheque : IBibliotheque {
    }
}
