using System.ComponentModel.DataAnnotations;

namespace api.web.mvc.Models.Users
{
    public class CreateUserViewModelInput
    {
        //using datas annotations
        [Required(ErrorMessage = "Login is Required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is Required. You can't create a account without password.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please, type your email.")]
        [EmailAddress(ErrorMessage = "Please, type a valid email.")]
        public string Email { get; set; }
    }
}
