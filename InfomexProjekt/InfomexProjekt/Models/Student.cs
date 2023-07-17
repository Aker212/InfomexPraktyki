using Microsoft.Build.Framework;

namespace InfomexProjekt.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string Email { get; set; }

        public DateTime DataUrodzenia { get; set; }

        public int RokRozpoczencia { get; set; }
    }
}
