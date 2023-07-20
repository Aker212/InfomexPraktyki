using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace InfomexProjekt.Models
{
    public class Student
    {

        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Imię jest wymagane.")]
        [StringLength(50, ErrorMessage = "Imię nie może przekraczać 50 znaków.")]
        public string Imie { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Nazwisko jest wymagane.")]
        [StringLength(50, ErrorMessage = "Nazwisko nie może przekraczać 50 znaków.")]
        public string Nazwisko { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Adres email jest wymagany.")]
        [StringLength(100, ErrorMessage = "Adres email nie może przekraczać 100 znaków.")]
        [EmailAddress(ErrorMessage = "Niepoprawny format adresu email.")]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Data urodzenia jest wymagana.")]
        [MinimumAge(18, ErrorMessage = "Student musi mieć skończone 18 lat.")]
        public DateOnly DataUrodzenia { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Imię jest wymagane.")]
        public int RokRozpoczencia { get; set; }
    }


public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                var currentDate = DateTime.Now;
                var dateOfBirth = date.AddYears(_minimumAge);

                if (dateOfBirth > currentDate)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
