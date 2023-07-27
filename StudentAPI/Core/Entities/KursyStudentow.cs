using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class KursyStudentow
    {
        public int IdStudenta { get; set; }
        public Student Student { get; set; }

        public int IdKursu { get; set; }
        public Kurs Kurs { get; set; }
    }
}
