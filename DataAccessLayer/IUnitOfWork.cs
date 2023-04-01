using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        void Commit();
    }
}
