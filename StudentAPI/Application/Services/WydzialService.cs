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
    public class WydzialService : IWydzialService
    {
        private readonly IWydzialRepository _wydzialRepository;
        private readonly IMapper _mapper;

        public WydzialService(IWydzialRepository wydzialRepository, IMapper mapper)
        {
            _wydzialRepository = wydzialRepository;
            _mapper = mapper;
        }

        public ListWydzialDto GetAllWydzialy()
        {
            var wydzialy = _wydzialRepository.GetAll();
            return _mapper.Map<ListWydzialDto>(wydzialy);
        }

        public WydzialDto GetWydzialById(int id)
        {
            var wydzial = _wydzialRepository.GetById(id);
            return _mapper.Map<WydzialDto>(wydzial);
        }

        public WydzialDto AddWydzial(AddWydzialDto newWydzial)
        {
            var wydzial = _mapper.Map<Wydzial>(newWydzial);
            _wydzialRepository.Add(wydzial);
            return _mapper.Map<WydzialDto>(wydzial);
        }

        public void UpdateWydzial(UpdateWydzialDto updateWydzial)
        {
            var existingWydzial = _wydzialRepository.GetById(updateWydzial.IdWydzialu);
            var wydzial = _mapper.Map(updateWydzial, existingWydzial);
            _wydzialRepository.Update(wydzial);
        }

        public void DeleteWydzial(int id)
        {
            var wydzial = _wydzialRepository.GetById(id);
            _wydzialRepository.Delete(wydzial);
        }
    }
}
