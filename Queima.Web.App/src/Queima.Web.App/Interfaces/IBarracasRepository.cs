using Queima.Web.App.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Interfaces
{
    public interface IBarracasRepository
    {
        void Add(Barraca b);
        void Edit(Barraca b);
        void Remove(int Id);
        IEnumerable GetBarracas();
        Barraca FindById(int Id);
    }

}
