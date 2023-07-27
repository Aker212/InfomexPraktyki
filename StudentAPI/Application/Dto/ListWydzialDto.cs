using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ListWydzialDto
    {
        public IEnumerable<WydzialDto> Wydzial { get; set; }
    }
}
