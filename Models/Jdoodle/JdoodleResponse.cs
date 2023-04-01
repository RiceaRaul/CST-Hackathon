namespace Models.Jdoodle
{

    public class JdoodleResponse
    {
        public string output { get; set; } = default!;
        public int statusCode { get; set; } = default!;
        public string memory { get; set; } = default!;
        public string cpuTime { get; set; } = default!;
        public object compilationStatus { get; set; } = default!;
    }

}
