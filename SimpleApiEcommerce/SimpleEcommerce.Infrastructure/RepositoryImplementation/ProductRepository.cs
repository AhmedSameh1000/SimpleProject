using SimpleEcommerce.Contract.RepositoryContracts;
using SimpleEcommerce.Domain.Entities;
using SimpleEcommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Infrastructure.RepositoryImplementation
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}