using EntityFramework.Entities;

namespace BLL_Labo.Interfaces
{
    public interface ILivreService
    {
        int? Create(Livre l);
        int Delete(int id);
        IEnumerable<Livre> Get();
        Livre Get(int id);
        int Update(int id, Livre livre);
        IEnumerable<Livre> ParAuteur(int id);
        IEnumerable<Livre> ParGenre(string genre);
    }
}