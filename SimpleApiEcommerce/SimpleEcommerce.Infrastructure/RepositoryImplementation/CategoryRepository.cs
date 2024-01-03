using Microsoft.EntityFrameworkCore;
using SimpleEcommerce.Contract.RepositoryContracts;
using SimpleEcommerce.Domain.Entities;
using SimpleEcommerce.Infrastructure.DbContext;

namespace SimpleEcommerce.Infrastructure.RepositoryImplementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<bool> IsExist(string CategoryName)
        {
            var isExist = await _DbContext.categories.FirstOrDefaultAsync(c => c.Name.ToUpperInvariant() == CategoryName.ToUpperInvariant());

            if (isExist != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}