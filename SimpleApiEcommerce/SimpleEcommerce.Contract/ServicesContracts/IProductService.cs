using SimpleEcommerce.Contract.DTOs.ProductDTOs;
using SimpleEcommerce.Domain.Entities;

namespace SimpleEcommerce.Contract.ServicesContracts
{
    public interface IProductService
    {
        public Task<Product> AddAsync(ProductDTO productDTO);

        public Task<List<ProductToReturnDto>> GetProducts();
    }
}