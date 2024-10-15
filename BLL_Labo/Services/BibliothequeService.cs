using Common_Labo.Repositories;
using EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Labo.Services {
    public class BibliothequeService : IBibliothequeRepository<Bibliotheque> {
        private DatabaseContext _dbContext;

        public BibliothequeService()
        {
            _dbContext = new DatabaseContext();
        }

        public int Create(Bibliotheque entity) {
            _dbContext.bibliotheques.Add(entity);
            _dbContext.SaveChanges();
            return entity.BibliothequeId;
        }

        public void Delete(int id) {
            Bibliotheque? bibliotheque = _dbContext.bibliotheques.Where(b => b.BibliothequeId == id).FirstOrDefault();
            _dbContext.bibliotheques.Remove(bibliotheque);
            _dbContext.SaveChanges();
        }

        public IQueryable<Bibliotheque> Get() {
            return _dbContext.bibliotheques;
        }

        public Bibliotheque? Get(int id) {
            return _dbContext.bibliotheques.Where(b => b.BibliothequeId == id).SingleOrDefault();
        }

        public void Update(int id, Bibliotheque entity) {
            throw new NotImplementedException();
        }
    }
}
