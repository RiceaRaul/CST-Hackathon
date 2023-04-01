using Models.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITaskService
    {
        Task<TaskModel> CreateTask(TaskCreateRequest request);
        Task<IEnumerable<TaskModel>> GetByProject(int project);
    }
}
