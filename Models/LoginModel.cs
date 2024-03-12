using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registration_Login.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsRemeber { get; set; }

    }
}
