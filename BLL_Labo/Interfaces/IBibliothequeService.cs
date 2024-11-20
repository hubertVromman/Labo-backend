using BLL_Labo.Entities;
using EntityFramework.Entities;

namespace BLL_Labo.Interfaces
{
    public interface IBibliothequeService
    {
        int Create(Bibliotheque b);
        int Delete(int id);
        IEnumerable<Bibliotheque> Get();
        Bibliotheque Get(int id);
        int Update(int id, Bibliotheque bibliotheque);
        int AjouterStock(StockForm s, bool enregistrerChangements = true);
        int SetStock(StockForm s);
        int RetirerStock(StockForm s);
        Bibliotheque AvecStock(int id);
    }
}