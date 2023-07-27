using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Wydzial
    {
        [Key]
        public int IdWydzialu { get; set; }
        public string NazwaWydzialu { get; set; }
        public string Budynek { get; set; }
    }
}
