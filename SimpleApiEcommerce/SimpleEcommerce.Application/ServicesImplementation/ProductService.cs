using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SimpleEcommerce.Contract.DTOs.ProductDTOs;
using SimpleEcommerce.Contract.RepositoryContracts;
using SimpleEcommerce.Contract.ServicesContracts;
using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.ServicesImplementation
{
    public class ProductService : IProductService
    {
        private readonly IWebHostEnvironment _Host;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly IProductRepository _ProductRepository;

        public ProductService(IWebHostEnvironment host,
            IHttpContextAccessor httpContextAccessor,
            IProductRepository productRepository
            )
        {
            _Host = host;
            _HttpContextAccessor = httpContextAccessor;
            _ProductRepository = productRepository;
        }

        public async Task<Product> AddAsync(ProductDTO productDTO)
        {
            string RootPath = _Host.WebRootPath;
            var ImageUrl = "";
            string fileName = Guid.NewGuid().ToString();
            string imageFolderPath = Path.Combine(RootPath, @"Images");
            string extension = Path.GetExtension(productDTO.file.FileName);
            using (FileStream fileStreams = new(Path.Combine(imageFolderPath,
                             fileName + extension), FileMode.Create))
            {
                productDTO.file.CopyTo(fileStreams);
            }

            ImageUrl = @$"{_HttpContextAccessor.HttpContext.Request.Scheme}://{_HttpContextAccessor.HttpContext.Request.Host}/Images/" + fileName + extension;

            var Product = new Product()
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                CategoryId = productDTO.CategoryId,
                DiscountRate = productDTO.DiscountRate,
                ImageUrl = ImageUrl,
                MinimumQuantity = productDTO.MinimumQuantity,
                ProductCode = Guid.NewGuid().ToString(),
            };
            await _ProductRepository.Add(Product);
            await _ProductRepository.SaveChanges();
            return Product;
        }
    }
}