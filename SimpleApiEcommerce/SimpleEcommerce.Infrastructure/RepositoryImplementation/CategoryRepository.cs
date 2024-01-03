using SimpleEcommerce.Contract.RepositoryContracts;
using SimpleEcommerce.Domain.Entities;
using SimpleEcommerce.Infrastructure.DbContext;

namespace SimpleEcommerce.Infrastructure.RepositoryImplementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
