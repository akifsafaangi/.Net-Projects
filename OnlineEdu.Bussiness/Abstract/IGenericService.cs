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
        List<T> GetAll();
        T GetById(int id);
        T GetByFilter(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Update(T entity);
        T Delete(int id);
        int Count();
        int FilteredCount(Expression<Func<T, bool>> predicate);
        List<T> GetFilteredList(Expression<Func<T, bool>> predicate);
    }
}
