using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IAdresRepository
    {
        Adres GetById(int id);
        IQueryable<Adres> GetAll();
        Adres Add(Adres adres);
        void Update(Adres adres);
        void Delete(Adres adres);
    }
}
