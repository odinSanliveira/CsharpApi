using api.web.mvc.Models.Users;
using Microsoft.AspNetCore.Mvc;
namespace api.web.mvc.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(CreateUserViewModelInput creatingUser) 
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModelInput userLogin)
        {
            return View();
        }


    }
}
