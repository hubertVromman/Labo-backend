using BLL_Labo.Entities;
using EntityFramework.Entities;

namespace BLL_Labo.Interfaces {
    public interface IPretService {
        int Create(Commande commande);
        Pret Get(int id);
        IEnumerable<Pret> Get();
        int Rendre(int id, int utilisateurId);
        IEnumerable<Pret> ParUtilisateur(int id);
    }
}