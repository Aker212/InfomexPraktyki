using Application.Dto;

namespace Application.Validators.Abstractions
{
    public interface IStudentValidator
    {
        public void Validate(AddStudentDto student);
        public void Validate(UpdateStudentDto student);
        public void Validate(int studentId);
    }
}
