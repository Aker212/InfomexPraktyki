using Application.Dto;

namespace Application.Services.Abstractions
{
    public interface IStudentService
    {
        ListStudentDto GetAllStudents();
        StudentDetailDto GetStudentById(int id);
        StudentDto AddStudent(AddStudentDto newStudent);
        void UpdateStudent(UpdateStudentDto updateStudent);
        void DeleteStudent(int id);

    }
}
