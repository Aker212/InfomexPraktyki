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
    public class AdresRepository : IAdresRepository
    {
        private readonly StudentAppContext _context;

        public AdresRepository(StudentAppContext context)
        {
            _context = context;
        }

        public IQueryable<Adres> GetAll()
        {
            return _context.Adres;
        }

        public Adres GetById(int id)
        {
            return _context.Adres.SingleOrDefault(x => x.IdAdresu == id);
        }

        public Adres Add(Adres adres)
        {
            _context.Adres.Add(adres);
            _context.SaveChanges();
            return adres;
        }

        public void Update(Adres adres)
        {
            _context.Adres.Update(adres);
            _context.SaveChanges();
        }

        public void Delete(Adres adres)
        {
            _context.Adres.Remove(adres);
            _context.SaveChanges();
        }
    }
}
