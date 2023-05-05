using Microsoft.IdentityModel.Tokens;
using ProjetoWeb.DTO;
using ProjetoWeb.Interfaces;
using ProjetoWeb.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace ProjetoWeb.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public JwtAuthentication GenerateJwtToken(AuthenticatedUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"] ?? string.Empty);
            var expires = DateTime.UtcNow.AddDays(int.Parse(_configuration["Jwt:ExpirationInDays"] ?? string.Empty));

            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new (JwtRegisteredClaimNames.Email, user.Email),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (ClaimTypes.Role, user.Role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtAuthentication
            {
                Token = tokenHandler.WriteToken(token),
                ExpiresAt = expires
            };
        }

        public async Task<User> ValidateCredentials(string email, string password)
        {
            var user = await _userRepository.GetUserByUserEmailAsync(email)
                       ?? throw new InvalidCredentialException("E-mail ou senha inválidos.");
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                throw new InvalidCredentialException("E-mail ou senha inválidos.");

            return user;
        }
    }
}
