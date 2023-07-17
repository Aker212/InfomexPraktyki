using InfomexProjekt.Models;

namespace InfomexProjekt.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> Create(Student student);
        Task<Student> GetById(int id);
        Task<List<Student>> GetAll();
        Task<Student> Update(Student student);
        Task Delete(int id);
    }
}
