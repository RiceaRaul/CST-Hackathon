namespace Models.Tasks
{
    public class TaskModel
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!; 
        public string Description { get; set; } = default!;
        public int Type { get; set; } = default!; 
        public string ResultCode { get; set; } = default!;
        public int ProjectId { get; set; } = default!;
    }
}
