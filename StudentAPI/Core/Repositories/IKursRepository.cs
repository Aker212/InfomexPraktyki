using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IKursRepository
    {
        Kurs GetById(int id);
        IQueryable<Kurs> GetAll();
        Kurs Add(Kurs kurs);
        void Update(Kurs kurs);
        void Delete(Kurs kurs);
    }
}
