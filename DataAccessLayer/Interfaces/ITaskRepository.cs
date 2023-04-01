using DataAccessLayer.Models;
using Models.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskDto> CreateTask(TaskCreateRequest request);
        Task<IEnumerable<TaskDto>> GetByProject(int project);
    }
}
