using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentication.Application.Common
{
    public interface IGenericRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression);
        Task DeleteByIdAsync(long Id);
        Task UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task<bool> IsEmailExists(Expression<Func<T, bool>> expression);

    }
}
