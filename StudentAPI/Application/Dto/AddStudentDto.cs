namespace Application.Dto
{
    public class AddStudentDto
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public DateOnly DataUrodzenia { get; set; }
        public int RokRozpoczencia { get; set; }

        public int IdAdres { get; set; }
        public int IdWydzialu { get; set; }
    }
}
