using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BlazorExample.Models
{
    public class User
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Name Empty!")]
        public string Name { get; set; }

        public UserSex.userSex? UserSex { get; set; } = Models.UserSex.userSex.Male;

        public bool IsActive { get; set; } = true;
    }
}
