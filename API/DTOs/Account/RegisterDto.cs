using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Account
{
    public class RegisterDto
    {

        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "First name must be at least {2}, and Maximum {1} Characters!")]
        public string FirstName { get; set; }
        [Required]
        //[StringLength(15, MinimumLength = 3, ErrorMessage = "Last name must be at least {2}, and Maximum {1} Characters!")]
        public string LastName { get; set; }

        [Required]
        //[RegularExpression("", ErrorMessage = " Invalide Emai  Address "  )]
        public string Email { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = " Password must be at least {2}, and Maximum {1} Characters!")]
        public string Password { get; set; }

    }
}
