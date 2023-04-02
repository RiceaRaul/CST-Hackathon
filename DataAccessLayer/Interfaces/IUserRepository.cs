using DataAccessLayer.Models;
using Models.Authentification;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> CreateUser(RegisterRequest request);
        Task<bool> LoginUser(AuthentificationRequest request);
        Task<UserDto> GetUserDetails(string username);
        Task<IEnumerable<UserDto>> GetLeaderBoard();
        Task<bool> UpdateExp(UpdateExpRequest request);
    }
}
