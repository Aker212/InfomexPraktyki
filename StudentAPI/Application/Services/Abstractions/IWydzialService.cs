using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IWydzialService
    {
        ListWydzialDto GetAllWydzialy();
        WydzialDto GetWydzialById(int id);
        WydzialDto AddWydzial(AddWydzialDto newWydzial);
        void UpdateWydzial(UpdateWydzialDto updateWydzial);
        void DeleteWydzial(int id);
    }
}
