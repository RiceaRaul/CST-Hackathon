namespace Common.Settings
{
    public class AppSettings
    {
        public string CorsOrigin { get; set; } = default!;
        public JWT JWT { get; set; } = default!;
        public Jdoodle Jdoodle { get; set; } = default!;
    }
}
