using DataAccessLayer.Models;
using Models.Projects;

namespace DataAccessLayer.Interfaces
{
    public interface IProjectRepository
    {
        Task<ProjectDto> CreateProject(CreateProjectRequest request);
        Task<IEnumerable<ProjectDto>> GetByUser(string username);
    }
}
