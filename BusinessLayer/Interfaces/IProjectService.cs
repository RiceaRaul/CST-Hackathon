using Models.Projects;

namespace BusinessLayer.Interfaces
{
    public interface IProjectService
    {
        Task<Project> CreateProject(CreateProjectRequest request);
        Task<IEnumerable<Project>> GetByUser(string username);
    }
}
