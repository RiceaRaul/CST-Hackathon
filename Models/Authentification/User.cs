using System.Runtime.Serialization;

namespace Models.Authentification
{
    public class User
    {
        public int Id { get; set; } = default!;
        public string Username { get; set; } = default!;
        [IgnoreDataMember]
        public string Password { get; set; } = default!;
        public string Level { get; set; } = default!;
        public long Experience { get; set; } = default!;
        public long NeedExperience { get; set; } = default!;
        public string ProfileImage { get; set; } = default!;
    }
}
