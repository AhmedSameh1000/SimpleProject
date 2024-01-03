using SimpleEcommerce.Domain.Entities;

namespace SimpleEcommerce.Contract.RepositoryContracts
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> IsExist(string CategoryName);
    }
}