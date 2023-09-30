using AutoMapper;
using CepCSharp_API.Entities.DomainEntities;
using CepCSharp_API.Entities.DTOs;

namespace CepCSharp_API.Entities.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile() 
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
