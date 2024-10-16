using EntityFramework.Entities;

namespace BLL_Labo.Interfaces
{
    public interface IAuteurService
    {
        int? Create(Auteur a);
        int Delete(int id);
        IEnumerable<Auteur> Get();
        Auteur Get(int id);
        int Update(int id, Auteur auteur);
    }
}