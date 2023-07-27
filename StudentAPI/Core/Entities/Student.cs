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


        public int IdAdresu { get; set; }
        public Adres Adres { get; set; }

        public int IdWydzialu { get; set; } // Klucz główny z klasy Wydzial
        public Wydzial Wydzial { get; set; } // Relacja jeden do jeden z klasą Wydzial
    }
}
