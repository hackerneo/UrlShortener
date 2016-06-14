using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, Boolean>> where);
        void Commit();
        T GetById(Int64 id);
        T GetById(String id);
        T Get(Expression<Func<T, Boolean>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, Boolean>> where);
        IEnumerable<T> GetPage<TOrder>(Int32 number, Int16 size, out Int32 total, Expression<Func<T, Boolean>> where, Expression<Func<T, TOrder>> order);
    }
}
