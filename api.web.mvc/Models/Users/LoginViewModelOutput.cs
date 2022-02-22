﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.web.mvc.Models.Users
{
    public class LoginViewModelOutput
    {
        public string Token { get; set; }
        public LoginViewModelDetailOutput User { get; set; }

    }
    public class LoginViewModelDetailOutput
    {
        public int Code { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }

    }
}
