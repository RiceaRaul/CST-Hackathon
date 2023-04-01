using System.Runtime.Serialization;

namespace Models.Projects
{
    public class CreateProjectRequest
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        [IgnoreDataMember]
        public string? Author { get; set; } = default!;
    }
}
