using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataTypes;

namespace DataAccess
{
    public class BaseRepository<T> where T : BaseModel
    {
        bool _disposed;
        protected DbContext DbContext { get; private set; }
        protected DbSet<T> Table
        {
            get { return DbContext.Set<T>(); }
        }
        public BaseRepository(DbContext context)
        {
            DbContext = context;
        }
        public virtual void Insert(T entity)
        {
            Table.Add(entity);
        }
       public virtual void Delete(T entity)
       {
           Table.Remove(entity);
       }
       public virtual void Update(T entity)
       {
           Table.Attach(entity);
           DbContext.Entry(entity).State = EntityState.Modified;
       }
       public T GetById(int id)
       {
           return Table.Find(id);
       }
       public long Count()
       {
           return Table.Count(); ;
       }
       public T GetSingle(Expression<Func<T, bool>> predicate)
       {
           return Table.FirstOrDefault(predicate);
       }
       public virtual void SaveChanges()
       {
           DbContext.SaveChanges();
       }

       public void Dispose()
       {
           Dispose(true);
           GC.SuppressFinalize(this);
       }

       public virtual void Dispose(bool disposing)
       {
           if (!_disposed)
           {
               if (disposing)
               {
                   DbContext.Dispose();
               }
           }
           _disposed = true;
       }
    }
}
