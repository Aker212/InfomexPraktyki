using Application.Dto;
using Application.Validators.Abstractions;
using Core.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Application.Validators
{
    public class StudentValidator : IStudentValidator
    {
        private readonly IStudentRepository _studentRepository;

        public StudentValidator(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Validate(AddStudentDto student)
        {
            ValidateName(student.Imie);
            ValidateName(student.Nazwisko);
            ValidateEmail(student.Email);
            ValidateDateOfBirth(student.DataUrodzenia);
        }

        public void Validate(UpdateStudentDto student)
        {
            IsExist(student.Id);
            ValidateName(student.Imie);
            ValidateName(student.Nazwisko);
            ValidateEmail(student.Email);
            ValidateDateOfBirth(student.DataUrodzenia);
        }

        public void Validate(int studentId)
        {
            IsExist(studentId);
        }

        private void IsExist(int id)
        {
            var student = _studentRepository.GetById(id);

            if (student is null)
            {
                throw new Exception($"Student z ID {id} nie istnieje.");
            }
        }




        private void ValidateName(string Nazwisko)
        {
            if (string.IsNullOrEmpty(Nazwisko))
            {
                throw new Exception("Nazwisko nie może być puste.");
            }

            if (Nazwisko.Length > 50)
            {
                throw new Exception("Nazwisko musi mieć mniej niż 50 znaków.");
            }
        }

        private void ValidateEmail(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("Email nie może być pusty.");
            }

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(emailPattern);

            if (!regex.IsMatch(Email))
            {
                throw new Exception("Niepoprawny format adresu email.");
            }

            if (Email.Length > 50)
            {
                throw new Exception("Email musi mieć mniej niż 50 znaków.");
            }

        }

        private void ValidateDateOfBirth(DateOnly? dateOfBirth)
        {
            if (!dateOfBirth.HasValue)
            {
                throw new Exception("Data urodzenia jest wymagana.");
            }

            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            DateOnly minDateOfBirth = today.AddYears(-18);

            if (dateOfBirth > minDateOfBirth)
            {
                throw new Exception("Osoba musi mieć co najmniej 18 lat.");
            }
        }





    }
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

       
    }
}
