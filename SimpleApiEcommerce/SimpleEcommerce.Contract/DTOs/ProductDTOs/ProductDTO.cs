using Microsoft.AspNetCore.Http;

namespace SimpleEcommerce.Contract.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MinimumQuantity { get; set; }
        public double DiscountRate { get; set; }
        public int CategoryId { get; set; }
        public IFormFile file { get; set; }
    }
}