using EntityFramework.Entities;

namespace BLL_Labo.Interfaces {
    public interface IGenreService {
        int? Create(Genre g);
        int Delete(int id);
        IEnumerable<Genre> Get();
        Genre Get(int id);
        int Update(int id, Genre genre);
    }
}