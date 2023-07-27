using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UpdateKursDto
    {
        public int IdKursu { get; set; }
        public string NazwaKursu { get; set; }
        public string Opis { get; set; }
    }
}
