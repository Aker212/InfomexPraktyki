using Core.Entities;
using Core.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentAppContext _context;

        public StudentRepository(StudentAppContext context)
        {
            _context = context;
        }

        public IQueryable<Student> GetAll()
        {
            return _context.Student;
        }

        public Student GetById(int id)
            => _context.Student.SingleOrDefault(x => x.Id == id);


        public Student Add(Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();
            return student;
        }

        public void Update(Student student)
        {
            _context.Student.Update(student);
            _context.SaveChanges();
        }

        public void Delete(Student student)
        {
            _context.Student.Remove(student);
            _context.SaveChanges();
        }
    }
}
