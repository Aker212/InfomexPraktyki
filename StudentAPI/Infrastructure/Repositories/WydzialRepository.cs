using Core.Entities;
using Core.Repositories;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class WydzialRepository : IWydzialRepository
    {
        private readonly StudentAppContext _context;

        public WydzialRepository(StudentAppContext context)
        {
            _context = context;
        }

        public IQueryable<Wydzial> GetAll()
        {
            return _context.Wydzial;
        }

        public Wydzial GetById(int id)
        {
            return _context.Wydzial.SingleOrDefault(x => x.IdWydzialu == id);
        }

        public Wydzial Add(Wydzial wydzial)
        {
            _context.Wydzial.Add(wydzial);
            _context.SaveChanges();
            return wydzial;
        }

        public void Update(Wydzial wydzial)
        {
            _context.Wydzial.Update(wydzial);
            _context.SaveChanges();
        }

        public void Delete(Wydzial wydzial)
        {
            _context.Wydzial.Remove(wydzial);
            _context.SaveChanges();
        }
    }
}
