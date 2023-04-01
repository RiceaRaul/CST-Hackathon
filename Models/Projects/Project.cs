using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Projects
{
    public class Project
    {
        public int Id { get; set; } = default!;
        public int Name { get; set; } = default!;
        public int Description { get; set; } = default!;
        public int Author { get; set; } = default!;
    }
}
