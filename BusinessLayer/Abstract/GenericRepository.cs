using DataAccessLayer.Context;
using Microsoft.Azure.Amqp.Framing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BusinessLayer.Abstract
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        DataContext db= new DataContext();
        DbSet<T> data;
        public GenericRepository()
        {
            data=db.Set<T>();
        }
        public void Add(T entity)
        {
            data.Add(entity);
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            data.Remove(entity);
            db.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return data.ToList();
        }

        public T GetById(int id)
        {
            return data.Find(id);
        }

        public void Update(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;   
            db.SaveChanges();
        }
    }
}
