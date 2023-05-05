using ProjetoWeb.Models;

namespace ProjetoWeb.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserEmailAsync(string userEmail);
    }
}
