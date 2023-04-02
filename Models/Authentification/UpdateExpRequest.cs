using System.Runtime.Serialization;

namespace Models.Authentification
{
    public class UpdateExpRequest
    {
        [IgnoreDataMember]
        public string? user { get; set; } = default!;
        public int exp_amount { get; set; } = default!;
    }
}
