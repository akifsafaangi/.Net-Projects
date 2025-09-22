using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Bussiness.Concrete
{
    public class GenericManager<T>(IRepository<T> _repository) : IGenericService<T> where T : class
    {
        public async Task<int> CountAsync()
        {
            return await _repository.CountAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _repository.CreateAsync(entity);
        }

        public async Task<T> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<int> FilteredCountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FilteredCountAsync(predicate);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetByFilterAsync(predicate);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetFilteredListAsync(predicate);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
