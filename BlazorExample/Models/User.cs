using System.ComponentModel.DataAnnotations;

namespace BlazorExample.Models
{
    public class User
    {
        [Required(ErrorMessage = "Id Empty!")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name Empty!")]
        public string? Name { get; set; }

        public UserSex.userSex UserSex { get; set; }

        public bool IsActive { get; set; }
    }
}
