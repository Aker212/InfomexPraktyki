using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IWydzialRepository
    {
        Wydzial GetById(int id);
        IQueryable<Wydzial> GetAll();
        Wydzial Add(Wydzial wydzial);
        void Update(Wydzial wydzial);
        void Delete(Wydzial wydzial);
    }
}
