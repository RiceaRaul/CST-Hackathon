using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class TaskDto
    {
        [Column("id")]
        public int Id { get; set; } = default!;
        [Column("name")]
        public string Name { get; set; } = default!;
        [Column("description")]
        public string Description { get; set; } = default!;
        [Column("type")]
        public int Type { get; set; } = default!;
        [Column("resultcode")]
        public string ResultCode { get; set; } = default!;
        [Column("projectid")]
        public int ProjectId { get; set; } = default!;
    }
}
