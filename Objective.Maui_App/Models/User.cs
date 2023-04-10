using SQLite;
using Objective.Maui_App.Models.Base;

namespace Objective.Maui_App.Models
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
