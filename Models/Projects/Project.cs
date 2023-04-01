namespace Models.Projects
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Author { get; set; }
    }
}
