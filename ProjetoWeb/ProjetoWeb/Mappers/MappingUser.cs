using AutoMapper;
using ProjetoWeb.DTO;
using ProjetoWeb.Models;

namespace ProjetoWeb.Mappers
{
    public class MappingUser
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, AuthenticatedUser>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdUser))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Profile.Name))
                    .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Admin == null ? "Student" : "Admin"));
            });
            
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
