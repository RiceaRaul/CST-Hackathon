using Models.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITaskService
    {
        Task<TaskModel> CreateTask(TaskCreateRequest request);
    }
}
