using SimpleEcommerce.Contract.DTOs.CategoryDTOs;
using SimpleEcommerce.Domain.Entities;

namespace SimpleEcommerce.Contract.ServicesContracts
{
    public interface ICategoryService
    {
        Task<Category> AddAsync(string CategoryName);

        Task<List<CategoryToReturnDTo>> GetCategories();
    }
}