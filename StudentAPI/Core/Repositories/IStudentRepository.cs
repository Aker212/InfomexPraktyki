using Core.Entities;

namespace Core.Repositories
{
    public interface IStudentRepository
    {
        Student GetById(int id);
        IQueryable<Student> GetAll();
        Student Add(Student student);
        void Update(Student student);
        void Delete(Student student);
    }
}
