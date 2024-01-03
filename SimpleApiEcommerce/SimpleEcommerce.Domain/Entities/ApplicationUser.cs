using Microsoft.AspNetCore.Identity;

namespace SimpleEcommerce.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public List<UserRefreshToken>? RefreshTokens { get; set; }
    }
}