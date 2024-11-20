using BLL_Labo.Interfaces;
using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Labo.Services {
    public class GenreService(DatabaseContext _dbContext) : IGenreService {
        public int Create(Genre g) {
            _dbContext.Add(g);
            _dbContext.SaveChanges();
            return g.GenreId;
        }

        public Genre Get(int id) {
            return _dbContext.genres.Where(g => g.GenreId == id).Include(g => g.Livres).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
        }

        public IEnumerable<Genre> Get() {
            return _dbContext.genres;
        }

        public int Update(int id, Genre genre) {
            Genre g = _dbContext.genres.Where(g => g.GenreId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
            g.NomGenre = genre.NomGenre;
            return _dbContext.SaveChanges();
        }

        public int Delete(int id) {
            Genre g = _dbContext.genres.Where(g => g.GenreId == id).FirstOrDefault() ?? throw new ArgumentOutOfRangeException();
            _dbContext.Remove(g);
            return _dbContext.SaveChanges();
        }
    }
}
