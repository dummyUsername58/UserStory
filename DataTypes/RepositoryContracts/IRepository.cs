using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EntityTypes
{
    public interface IRepository<T>:IDisposable
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        long Count();
        void SaveChanges();
    }
}
