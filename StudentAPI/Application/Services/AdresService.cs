using Application.Dto;
using Application.Services.Abstractions;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdresService : IAdresService
    {
        private readonly IAdresRepository _adresRepository;
       
        private readonly IMapper _mapper;

        public AdresService(IAdresRepository adresRepository, IMapper mapper)
        {
            _adresRepository = adresRepository;
           
            _mapper = mapper;
        }

        public ListAdresDto GetAllAdresy()
        {
            var adresy = _adresRepository.GetAll();
            return _mapper.Map<ListAdresDto>(adresy);
        }

        public AdresDto GetAdresById(int IdAdresu)
        {
            var adres = _adresRepository.GetById(IdAdresu);
            return _mapper.Map<AdresDto>(adres);
        }

        public AdresDto AddAdres(AddAdresDto newAdres)
        {
            

            var adres = _mapper.Map<Adres>(newAdres);

            _adresRepository.Add(adres);

            return _mapper.Map<AdresDto>(adres);
        }

        public void UpdateAdres(UpdateAdresDto updateAdres)
        {
          

            var existingAdres = _adresRepository.GetById(updateAdres.IdAdresu);

            var adres = _mapper.Map(updateAdres, existingAdres);

            _adresRepository.Update(adres);
        }

        public void DeleteAdres(int IdAdresu)
        {
            

            var adres = _adresRepository.GetById(IdAdresu);

            _adresRepository.Delete(adres);
        }
    }
}
