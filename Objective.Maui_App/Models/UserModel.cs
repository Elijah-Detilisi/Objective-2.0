using SQLite;
using Objective.Maui_App.Models.Base;

namespace Objective.Maui_App.Models
{
    [Table(nameof(UserModel))]
    public class UserModel : Model
    {
        public UserModel()
        {
            ProfilePictureUrl = "default.png";
        }
        [Unique, MaxLength(50)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
