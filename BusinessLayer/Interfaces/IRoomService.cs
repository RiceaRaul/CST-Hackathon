using Models.Rooms;

namespace BusinessLayer.Interfaces
{
    public interface IRoomService
    {
        Task<Room> GenerateRoom();
        Task<Room> GetRoomByCode(string roomcode);
        Task<bool> CloseRoom(string roomcode);
    }
}
