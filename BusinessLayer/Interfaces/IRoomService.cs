using Models.Rooms;

namespace BusinessLayer.Interfaces
{
    public interface IRoomService
    {
        Task<Room> GenerateRoom();
    }
}
