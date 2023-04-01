namespace Models.Jdoodle
{
    public class JdoodleResponse
    {
        public string clientId { get; set; } = default!;
        public string clientSecret { get; set; } = default!;
        public string script { get; set; } = default!;
        public string language { get; set; } = default!;
        public string versionIndex { get; set; } = default!;
    }
}
