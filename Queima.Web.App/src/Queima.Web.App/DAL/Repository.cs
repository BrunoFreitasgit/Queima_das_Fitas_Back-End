using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Queima.Web.App.Helpers;
using Queima.Web.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.DAL
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly QueimaDbContext _db;

        public Repository(QueimaDbContext db)
        {
            _db = db;
        }

        public void Add(T entity)
        {
            EntityEntry<T> dbEntityEntry = _db.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                _db.Add(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;

            Delete(entity);
        }

        public void Delete(T entity)
        {
            EntityEntry<T> dbEntityEntry = _db.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _db.Set<T>().Attach(entity);
                _db.Set<T>().Remove(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            EntityEntry<T> dbEntityEntry = _db.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                _db.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}

