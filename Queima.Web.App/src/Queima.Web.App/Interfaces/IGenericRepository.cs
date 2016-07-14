using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Queima.Web.App.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task Save(T employee);
        Task Delete(T employee);
        Task Update(T employee);
        Task<IEnumerable<T>> FindAll();
    }
}
