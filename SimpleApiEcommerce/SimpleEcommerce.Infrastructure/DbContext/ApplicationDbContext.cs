using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleEcommerce.Domain.Entities;

namespace SimpleEcommerce.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserRefreshToken> RefreshTokens { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}