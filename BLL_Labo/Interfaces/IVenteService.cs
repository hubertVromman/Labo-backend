using BLL_Labo.Entities;
using EntityFramework.Entities;

namespace BLL_Labo.Interfaces {
    public interface IVenteService {
        int Create(Commande commande);
        Vente? Get(int id);
        IEnumerable<Vente> Get();
    }
}