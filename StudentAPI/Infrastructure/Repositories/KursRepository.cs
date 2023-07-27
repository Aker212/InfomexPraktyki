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
    public class KursRepository : IKursRepository
    {
        private readonly StudentAppContext _context;

        public KursRepository(StudentAppContext context)
        {
            _context = context;
        }

        public IQueryable<Kurs> GetAll()
        {
            return _context.Kursy;
        }

        public Kurs GetById(int id)
        {
            return _context.Kursy.SingleOrDefault(x => x.IdKursu == id);
        }

        public Kurs Add(Kurs kurs)
        {
            _context.Kursy.Add(kurs);
            _context.SaveChanges();
            return kurs;
        }

        public void Update(Kurs kurs)
        {
            _context.Kursy.Update(kurs);
            _context.SaveChanges();
        }

        public void Delete(Kurs kurs)
        {
            _context.Kursy.Remove(kurs);
            _context.SaveChanges();
        }
    }
}
