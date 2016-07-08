using Queima.Web.App.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Interfaces
{
    public interface IAtividadesRepository
    {
        void Add(AtividadeAcademica a);
        void Edit(AtividadeAcademica a);
        void Remove(int Id);
        IEnumerable GetAtividadesAcademicas();
        AtividadeAcademica FindById(int Id);
    }
}
