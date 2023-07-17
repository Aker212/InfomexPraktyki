using InfomexProjekt.Interfaces;
using Microsoft.EntityFrameworkCore;
using InfomexProjekt.Models;
using InfomexProjekt.DbContext;

namespace InfomexProjekt.Interfaces
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> Create(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student> GetById(int id)
        {
            return await _dbContext.Students.FindAsync(id);
        }

        public async Task<List<Student>> GetAll()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> Update(Student student)
        {
            _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync();
            return student;
        }

        public async Task Delete(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
