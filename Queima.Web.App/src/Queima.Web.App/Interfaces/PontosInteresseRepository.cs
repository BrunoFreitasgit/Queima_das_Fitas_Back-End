using Microsoft.EntityFrameworkCore;
using Queima.Web.App.DAL;
using Queima.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Interfaces
{
    public class PontosInteresseRepository : IRepository<PontoInteresse>
    {
        public QueimaDbContext _db;
        public PontosInteresseRepository(QueimaDbContext db)
        {
            _db = db;
        }
        public void Add(PontoInteresse entity)
        {
            if (entity != null)
            {
                _db.PontosInteresse.Add(entity);
            }
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id != 0)
            {
                var ponto = _db.PontosInteresse.SingleOrDefault(p => p.PontoInteresseID == id);

                if (ponto != null)
                {
                    _db.PontosInteresse.Remove(ponto);
                }
            }
            _db.SaveChanges();
        }

        public void Delete(PontoInteresse entity)
        {
            if (entity != null)
            {
                _db.PontosInteresse.Remove(entity);
            }
            _db.SaveChanges();
        }

        public IQueryable<PontoInteresse> GetAll()
        {
            return _db.PontosInteresse;
        }

        public PontoInteresse GetById(int id)
        {
            return _db.PontosInteresse.SingleOrDefault(p => p.PontoInteresseID == id);
        }

        public void Update(PontoInteresse entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
