﻿using api.web.mvc.Models.Users;
using api.web.mvc.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Threading.Tasks;

namespace api.web.mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModelInput creatingUser) 
        {
            try
            {
                var user = await _userService.Register(creatingUser);
                ModelState.AddModelError("", $"Your account has been successfully registred. Welcome {user.Login}");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            ////Due to SSL connection
            ////security policy handling is required. (It ins't a good development practice)
            //HttpClientHandler clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            //var Client = new HttpClient(clientHandler);
            //Client.BaseAddress = new Uri("https://localhost:44314/");

            //var registerUser = JsonConvert.SerializeObject(creatingUser);
            //var HttpContent = new StringContent(registerUser, Encoding.UTF8, "application/json");
            //var HttpPost = Client.PostAsync("/api/v1/user/register", HttpContent).GetAwaiter().GetResult();

            //if(HttpPost.StatusCode == System.Net.HttpStatusCode.Created)
            //{
            //    ModelState.AddModelError("", "Your account has been successfully registred.");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Your account has not been registred.");
            //}
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModelInput userLogin)
        {
            try
            {
                var user = await _userService.Login(userLogin);
                ModelState.AddModelError("", $"Welcome, {user.User} with token: {user.Token}");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }


    }
}
