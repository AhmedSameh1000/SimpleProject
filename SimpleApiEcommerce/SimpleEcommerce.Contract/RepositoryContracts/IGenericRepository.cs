using SimpleEcommerce.Contract.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace SimpleEcommerce.Contract.RepositoryContracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsTracking(string[] InclueProperties = null);

        Task<IPagedList<T>> GetAllAsTracking(RequestParams requestParams, string[] InclueProperties = null);

        Task<IEnumerable<T>> GetAllAsNoTracking(string[] InclueProperties = null);

        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string[] InclueProperties = null);

        Task Add(T entity);

        void Update(T entity);

        void Remove(T Entity);

        Task<bool> SaveChanges();
    }
}