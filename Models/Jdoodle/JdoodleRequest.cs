using System.Runtime.Serialization;

namespace Models.Jdoodle
{
    public class JdoodleRequest
    {
        [IgnoreDataMember]
        public string? clientId { get; set; } = default!;
        [IgnoreDataMember]
        public string? clientSecret { get; set; } = default!;
        public string script { get; set; } = default!;
        public string language { get; set; } = default!;
        public string versionIndex { get; set; } = default!;
    }

    public class JdoodleRequestSend
    {
        public string? clientId { get; set; } = default!;
        public string? clientSecret { get; set; } = default!;
        public string script { get; set; } = default!;
        public string language { get; set; } = default!;
        public string versionIndex { get; set; } = default!;
    }
}
