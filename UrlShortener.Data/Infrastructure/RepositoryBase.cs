using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Data;

namespace UrlShortener.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private readonly IDbSet<T> dbset;

        protected RepositoryBase(IDatabaseFactory factory)
        {
            DataContext = factory.Get();
            dbset = DataContext.Set<T>();
        }

        protected UrlShortenerEntities DataContext
        {
            get;
            private set;
        }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, Boolean>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }

        public void Commit()
        {
            DataContext.SaveChanges();
        }

        public virtual T GetById(Int64 id)
        {
            return dbset.Find(id);
        }

        public virtual T GetById(String id)
        {
            return dbset.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, Boolean>> where)
        {
            return dbset.Where(where).ToList();
        }

        public virtual IEnumerable<T> GetPage<TOrder>(Int32 number, Int16 size, out Int32 total, Expression<Func<T, Boolean>> where, Expression<Func<T, TOrder>> order)
        {
            total = dbset.Count(where);
            return dbset.OrderBy(order).Where(where).Skip((number - 1) * size).Take(size).ToList();
        }

        public T Get(Expression<Func<T, Boolean>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }
    }
}