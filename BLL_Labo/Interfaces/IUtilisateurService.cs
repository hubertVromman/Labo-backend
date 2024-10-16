using EntityFramework.Entities;

namespace BLL_Labo.Interfaces
{
    public interface IUtilisateurService
    {
        List<Utilisateur> GetAll();
        Utilisateur? GetUserByEmail(string email);
        bool Register(string email, string motDePasse, string nom, string prenom);
        int ChangeRole(int id, string nouveauRole);
    }
}
