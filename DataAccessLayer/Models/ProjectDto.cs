using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class ProjectDto
    {
        [Column("id")]
        public int Id { get; set; } = default!;
        [Column("name")]
        public int Name { get; set; } = default!;
        [Column("description")]
        public int Description { get; set; } = default!;
        [Column("author")]
        public int Author { get; set; } = default!;
    }
}
