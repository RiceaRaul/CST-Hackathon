using AutoMapper;
using DataAccessLayer.Models;
using Models.Authentification;

namespace BusinessLayer.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();
        }
    }
}
