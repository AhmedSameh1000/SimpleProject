using SimpleEcommerce.Contract.DTOs.CategoryDTOs;
using SimpleEcommerce.Contract.RepositoryContracts;
using SimpleEcommerce.Contract.ServicesContracts;
using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.ServicesImplementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }

        public async Task<Category> AddAsync(string CategoryName)
        {
            if (CategoryName is null)
            {
                throw new ArgumentNullException("Category Cant Be Null");
            }
            var Category = new Category()
            {
                Name = CategoryName,
            };

            await _CategoryRepository.Add(Category);
            await _CategoryRepository.SaveChanges();

            return Category;
        }

        public async Task<List<CategoryToReturnDTo>> GetCategories()
        {
            var Categories = await _CategoryRepository.GetAllAsNoTracking();
            var CategoryToReturn = Categories.Select(c => new CategoryToReturnDTo
            {
                CategoryId = c.Id,
                Name = c.Name,
            }).ToList();

            return CategoryToReturn;
        }
    }
}