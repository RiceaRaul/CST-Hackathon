using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IRoomRepository
    {
        Task<RoomDto> GenerateRoom();
        Task<RoomDto> GetRoomByCode(string roomcode);
        Task<bool> CloseRoom(string roomcode);
    }
}
