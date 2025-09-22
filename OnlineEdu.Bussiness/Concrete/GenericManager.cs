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
        public int Count()
        {
            return _repository.Count();
        }

        public void Create(T entity)
        {
            _repository.Create(entity);
        }

        public T Delete(int id)
        {
           return _repository.Delete(id);
        }

        public int FilteredCount(Expression<Func<T, bool>> predicate)
        {
            return _repository.FilteredCount(predicate);
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetByFilter(predicate);
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetFilteredList(predicate);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
