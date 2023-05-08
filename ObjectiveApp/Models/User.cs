using SQLite;
using ObjectiveApp.Models.Base;

namespace ObjectiveApp.Models
{
    [Table(nameof(User))]
    public class User : BaseModel
    {
        [Unique, MaxLength(50)]
        public string Username { get; set; } = "User";

        [MaxLength(100)]
        public string ProfilePictureUrl { get; set; } = "Profile.png";
    }
}
