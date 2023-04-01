using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IRoomRepository
    {
        Task<RoomDto> GenerateRoom();
    }
}
