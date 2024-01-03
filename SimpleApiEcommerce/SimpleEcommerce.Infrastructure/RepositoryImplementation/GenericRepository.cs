using Microsoft.EntityFrameworkCore;
using SimpleEcommerce.Contract.Helpers;
using SimpleEcommerce.Contract.RepositoryContracts;
using SimpleEcommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace SimpleEcommerce.Infrastructure.RepositoryImplementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsNoTracking(string[] InclueProperties = null)
        {
            IQueryable<T> Query = _dbContext.Set<T>().AsNoTracking().AsQueryable();
            if (InclueProperties != null)
            {
                foreach (var includeProperty in InclueProperties)
                {
                    Query = Query.Include(includeProperty.Trim());
                }
            }

            return await Query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsTracking(string[] InclueProperties = null)
        {
            IQueryable<T> Query = _dbContext.Set<T>().AsQueryable();
            if (InclueProperties != null)
            {
                foreach (var includeProperty in InclueProperties)
                {
                    Query = Query.Include(includeProperty.Trim());
                }
            }

            return await Query.ToListAsync();
        }

        public async Task<IPagedList<T>> GetAllAsTracking(RequestParams requestParams, string[] InclueProperties = null)
        {
            IQueryable<T> Query = _dbContext.Set<T>();
            if (InclueProperties != null)
            {
                foreach (var includeProperty in InclueProperties)
                {
                    Query = Query.Include(includeProperty.Trim());
                }
            }

            return await Query.ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string[] InclueProperties = null)
        {
            IQueryable<T> Query = _dbContext.Set<T>().AsQueryable();
            Query = Query.Where(filter);
            if (InclueProperties != null)
            {
                foreach (var includeProperty in InclueProperties)
                {
                    Query = Query.Include(includeProperty.Trim());
                }
            }

            return await Query.FirstOrDefaultAsync();
        }

        public void Remove(T Entity)
        {
            _dbContext.Set<T>().Remove(Entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public async Task<bool> SaveChanges()
        {
            var RowsEfected = await _dbContext.SaveChangesAsync();
            return RowsEfected > 0 ? true : false;
        }
    }
}