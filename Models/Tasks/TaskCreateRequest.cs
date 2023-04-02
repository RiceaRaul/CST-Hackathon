using System.Runtime.Serialization;

namespace Models.Tasks
{
    public class TaskCreateRequest
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Type { get; set; } = default!;
        public string ResultCode { get; set; } = default!;
        public int ProjectId { get; set; } = default!;
        [IgnoreDataMember]
        public string? Author { get; set; } = default!;
    }
}
