using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Kurs
    {
        [Key]
        public int IdKursu { get; set; }
        public string NazwaKursu { get; set; }
        public string Opis { get; set; }
        
    }
}
