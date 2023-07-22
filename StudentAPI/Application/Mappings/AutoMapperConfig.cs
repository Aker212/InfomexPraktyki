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

          })
          .CreateMapper();
    }
}
