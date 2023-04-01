using DataAccessLayer.Models;
using Models.Authentification;

namespace BusinessLayer.Interfaces
{
    public interface IAuthentificationService
    {
        Task<AuthentificationResponse?> Authentificate(AuthentificationRequest request);
        Task<User> CreateUser(RegisterRequest request);
        Task<User> GetUserDetails(string username);
    }
}
