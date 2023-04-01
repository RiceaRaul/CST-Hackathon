using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProjectRepository ProjectRepository { get; }
        ITaskRepository TaskRepository { get; }
        IRoomRepository RoomRepository { get; }

        void Commit();
    }
}
