using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Rooms
{
    public class Room
    {
        public int Id { get; set; } = default;
        public string RoomCode { get; set; } = default!;
        public int Status { get; set; } = default;
    }
}
