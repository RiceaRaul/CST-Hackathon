using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class RoomDto
    {
        [Column("id")]
        public int Id { get; set; } = default;
        [Column("roomcode")]
        public string RoomCode { get; set; } = default!;
        [Column("status")]
        public int Status { get; set; } = default;
    }
}
