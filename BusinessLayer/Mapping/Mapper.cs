using AutoMapper;
using DataAccessLayer.Models;
using Models.Authentification;
using Models.Jdoodle;
using Models.Projects;
using Models.Rooms;
using Models.Tasks;

namespace BusinessLayer.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();  
            CreateMap<JdoodleRequest, JdoodleRequestSend>()
                .ReverseMap();
            CreateMap<Project, ProjectDto>()
                .ReverseMap();

            CreateMap<TaskModel, TaskDto>()
               .ReverseMap();
            CreateMap<Room, RoomDto>()
             .ReverseMap();
        }
    }
}
