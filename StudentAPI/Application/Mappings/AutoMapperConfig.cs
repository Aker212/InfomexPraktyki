using Application.Dto;
using AutoMapper;
using Core.Entities;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
          => new MapperConfiguration(cfg =>
          {
              #region Student    

              cfg.CreateMap<Student, StudentDto>();
              cfg.CreateMap<Student, StudentDetailDto>();
              cfg.CreateMap<AddStudentDto, Student>();
              cfg.CreateMap<UpdateStudentDto, Student>();

              cfg.CreateMap<IEnumerable<Student>, ListStudentDto>()
               .ForMember(dest => dest.Students, act => act.MapFrom(src => src))
               .ForMember(dest => dest.Count, act => act.MapFrom(src => src.Count()));

              #endregion

              #region Adres

              cfg.CreateMap<Adres, AdresDto>();
              cfg.CreateMap<AddAdresDto, Adres>();
              cfg.CreateMap<UpdateAdresDto, Adres>();

              cfg.CreateMap<IEnumerable<Adres>, ListAdresDto>()
             .ForMember(dest => dest.Adres, act => act.MapFrom(src => src));

              #endregion

              #region Kurs

              cfg.CreateMap<Kurs, KursDto>();
              cfg.CreateMap<AddKursDto, Kurs>();
              cfg.CreateMap<UpdateKursDto, Kurs>();

              cfg.CreateMap<IEnumerable<Kurs>, ListKursDto>()
             .ForMember(dest => dest.Kurs, act => act.MapFrom(src => src));

              #endregion

              #region Wydzial
              cfg.CreateMap<Wydzial, WydzialDto>();
              cfg.CreateMap<AddWydzialDto, Wydzial>();
              cfg.CreateMap<UpdateWydzialDto, Wydzial>();

              cfg.CreateMap<IEnumerable<Wydzial>, ListWydzialDto>()
             .ForMember(dest => dest.Wydzial, act => act.MapFrom(src => src));

              #endregion


          })
          .CreateMapper();
    }
}
