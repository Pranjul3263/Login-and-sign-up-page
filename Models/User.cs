using System.ComponentModel.DataAnnotations;

namespace Registration_Login.Models
{
    public class User
    {
        
        public int Id { get; set; }

         public string? UserName { get; set; }


        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public bool IsActive { get; set;}

        public bool IsRemeber { get; set; }

    }
}
