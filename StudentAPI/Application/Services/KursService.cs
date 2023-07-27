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
    public class KursService : IKursService
    {
        private readonly IKursRepository _kursRepository;
        private readonly IMapper _mapper;

        public KursService(IKursRepository kursRepository, IMapper mapper)
        {
            _kursRepository = kursRepository;
            _mapper = mapper;
        }

        public ListKursDto GetAllKursy()
        {
            var kursy = _kursRepository.GetAll();
            return _mapper.Map<ListKursDto>(kursy);
        }

        public KursDto GetKursById(int idKursu)
        {
            var kurs = _kursRepository.GetById(idKursu);
            return _mapper.Map<KursDto>(kurs);
        }

        public KursDto AddKurs(AddKursDto newKurs)
        {
            var kurs = _mapper.Map<Kurs>(newKurs);
            _kursRepository.Add(kurs);
            return _mapper.Map<KursDto>(kurs);
        }

        public void UpdateKurs(UpdateKursDto updateKurs)
        {
            var existingKurs = _kursRepository.GetById(updateKurs.IdKursu);
            var kurs = _mapper.Map(updateKurs, existingKurs);
            _kursRepository.Update(kurs);
        }

        public void DeleteKurs(int idKursu)
        {
            var kurs = _kursRepository.GetById(idKursu);
            _kursRepository.Delete(kurs);
        }
    }
}
