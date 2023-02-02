using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BlazorExample.Models
{
    public class User
    {
        [Required(ErrorMessage = "Id Empty!")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name Empty!")]
        public string Name { get; set; }

        public UserSex.userSex? UserSex { get; set; }

        public bool IsActive { get; set; }
    }
}
