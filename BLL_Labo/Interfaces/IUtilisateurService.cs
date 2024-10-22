using EntityFramework.Entities;

namespace BLL_Labo.Interfaces
{
    public interface IUtilisateurService
    {
        IEnumerable<Utilisateur> GetAll();
        Utilisateur GetUserByEmail(string email);
        Utilisateur Login(string email, string motDePasse);
        bool Register(string email, string motDePasse, string nom, string prenom);
        int ChangeRole(int id, string nouveauRole);
    }
}
