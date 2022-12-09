using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproach.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }



        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password",
            ErrorMessage = "Comfirm password is not matched with Password")]
        public string ConfirmPassword { get; set; }
    }
}
