using AutoFixture;
using FluentAssertions;
using Moq;
using SimpleEcommerce.Application.ServicesImplementation;
using SimpleEcommerce.Contract.RepositoryContracts;
using SimpleEcommerce.Contract.ServicesContracts;
using SimpleEcommerce.Domain.Entities;

namespace SimpleEcommerce.Testing
{
    public class CategoryServiceTest
    {
        private readonly Mock<ICategoryRepository> _Mock;
        private readonly IFixture _fixture;
        private readonly ICategoryRepository _CategoryRepository;
        private readonly ICategoryService _CategoryService;

        public CategoryServiceTest()
        {
            _fixture = new Fixture();
            _Mock = new Mock<ICategoryRepository>();
            _CategoryRepository = _Mock.Object;
            _CategoryService = new CategoryService(_CategoryRepository);
        }

        [Fact]
        public async Task CreateCategory_NullCategory()
        {
            string CategoryName = null;

            var Actual = async () =>
            {
                await _CategoryService.AddAsync(CategoryName);
            };

            await Actual.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task GetAllCategories_EmptyList()
        {
            IEnumerable<Category> list = new List<Category>();

            _Mock.Setup(c => c.GetAllAsNoTracking(It.IsAny<string[]>())).ReturnsAsync(list);

            // Act
            var result = await _CategoryService.GetCategories();
            result.Should().BeEmpty();
        }
    }
}