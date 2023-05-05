using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Interfaces;
using ProjetoWeb.Models;

namespace ProjetoWeb.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WebApiContext _context;

        public UserRepository(WebApiContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUserEmailAsync(string userEmail)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
        }
    }
}