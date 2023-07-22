namespace Core.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string Email { get; set; }

        public DateOnly DataUrodzenia { get; set; }

        public int RokRozpoczencia { get; set; }
    }
}
