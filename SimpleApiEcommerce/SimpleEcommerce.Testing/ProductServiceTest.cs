using AutoFixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Moq;
using SimpleEcommerce.Application.ServicesImplementation;
using SimpleEcommerce.Contract.DTOs.ProductDTOs;
using SimpleEcommerce.Contract.RepositoryContracts;
using SimpleEcommerce.Contract.ServicesContracts;
using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Testing
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductRepository> _ProductMock;
        private readonly Mock<IWebHostEnvironment> _iHostMock;
        private readonly Mock<IHttpContextAccessor> _HttpcontextMock;

        private readonly IProductRepository _ProductRepository;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IHttpContextAccessor _HttpContextAccessor;

        private readonly IProductService _ProductService;

        public ProductServiceTest()
        {
            _ProductMock = new Mock<IProductRepository>();
            _iHostMock = new Mock<IWebHostEnvironment>();

            _HttpcontextMock = new Mock<IHttpContextAccessor>();

            _WebHostEnvironment = _iHostMock.Object;
            _ProductRepository = _ProductMock.Object;
            _HttpContextAccessor = _HttpcontextMock.Object;

            _ProductService = new ProductService(_WebHostEnvironment, _HttpContextAccessor, _ProductRepository);
        }

        [Fact]
        public async Task Addproduct_NullProduct()
        {
            ProductDTO? product = null;
            _ProductMock.Setup(c => c.Add(It.IsAny<Product>())).Returns(Task.CompletedTask);
            var Actual = async () =>
            {
                await _ProductService.AddAsync(product);
            };
            await Actual.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task AddProductname_ProductNameIsNull()
        {
            _ProductMock.Setup(c => c.Add(It.IsAny<Product>())).Returns(Task.CompletedTask);

            var Actual = await _ProductService.AddAsync(new ProductDTO()
            {
                Name = null
            });

            Actual.Should().BeNull();
        }

        [Fact]
        public async Task GetAllProducts_EmptyList()
        {
            var products = new List<Product>();

            _ProductMock.Setup(p => p.GetAllAsNoTracking(It.IsAny<string[]>()))
                .ReturnsAsync(products);

            var Products = await _ProductService.GetProducts();

            Products.Should().BeEmpty();
        }
    }
}