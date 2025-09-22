using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Bussiness.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<int> CountAsync();
        Task CreateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<int> FilteredCountAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllAsync();
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate);
        Task UpdateAsync(T entity);
    }
}
