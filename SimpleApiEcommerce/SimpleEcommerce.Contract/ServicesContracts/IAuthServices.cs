using SimpleEcommerce.Contracts.DTOs.AuthDTOs;
using SimpleEcommerce.Domain.Entities;

namespace SimpleEcommerce.Contracts.ServicesContracts
{
    public interface IAuthServices
    {
        Task<AuthModel> RegisterAsync(RegisterDto model);

        Task<AuthModel> LoginAsync(LogInDTo model);

        Task<string> GenerateToken(ApplicationUser user);

        Task<AuthModel> RefreshTokenAsync(string userId);
    }
}