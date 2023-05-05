using ProjetoWeb.DTO;
using ProjetoWeb.Models;

namespace ProjetoWeb.Interfaces
{
    public interface IAuthService
    {
        JwtAuthentication GenerateJwtToken(AuthenticatedUser user);
        Task<User> ValidateCredentials(string email, string password);
    }
}