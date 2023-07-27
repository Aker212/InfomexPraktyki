using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IAdresService
    {
        ListAdresDto GetAllAdresy();
        AdresDto GetAdresById(int id);
        AdresDto AddAdres(AddAdresDto newAdres);
        void UpdateAdres(UpdateAdresDto updateAdres);
        void DeleteAdres(int id);
    }
}
