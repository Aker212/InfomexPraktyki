using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IKursService
    {
        ListKursDto GetAllKursy();
        KursDto GetKursById(int id);
        KursDto AddKurs(AddKursDto newKurs);
        void UpdateKurs(UpdateKursDto updateKurs);
        void DeleteKurs(int id);
    }
}
