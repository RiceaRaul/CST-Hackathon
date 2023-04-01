using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class UserDto
    {
        [Column("id")]
        public int Id { get; set; } = default!;
        [Column("username")]
        public string Username { get;set; } = default!;
        [Column("password")]
        public string Password { get; set; } = default!;
        [Column("level")]
        public string Level { get; set; } = default!;
        [Column("exp")]
        public long Experience { get; set; } = default!;
        [Column("needxp")]
        public long NeedExperience { get; set; } = default!;
        [Column("profileimg")]
        public string ProfileImage { get; set; } = default!;
    }
}
