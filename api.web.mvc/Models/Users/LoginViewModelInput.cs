using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.web.mvc.Models.Users
{
    public class LoginViewModelInput
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
