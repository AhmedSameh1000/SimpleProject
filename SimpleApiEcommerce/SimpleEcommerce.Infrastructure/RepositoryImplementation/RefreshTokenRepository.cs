using SimpleEcommerce.Contract.RepositoryContracts;
using SimpleEcommerce.Domain.Entities;
using SimpleEcommerce.Infrastructure.DbContext;

namespace SimpleEcommerce.Infrastructure.RepositoryImplementation
{
    public class RefreshTokenRepository : GenericRepository<UserRefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
