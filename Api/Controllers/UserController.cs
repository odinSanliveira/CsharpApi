using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Models.User;
using CsharpApi.Business.Entities;
using CsharpApi.Business.Repositories;
using CsharpApi.Configurations;
using CsharpApi.Filters;
using CsharpApi.Infrastructure.Data;
using CsharpApi.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public UserController(IUserRepository userRepository, IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns>User status, user data and user token</returns>

        [SwaggerResponse(statusCode: 200, description: "Authentication success", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Required Field", Type = typeof(FieldValidationViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Internal error", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("login")]
        [CustomModelStateValidation]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            User user = _userRepository.GetUser(loginViewModelInput.Login);

            if(user == null)
            {
                return BadRequest("There was an error trying to access.");
            }
            var userViewModelOutput = new UserViewModelOutput()
            {
                Code = user.Code,
                Login = user.Login,
                Email = user.Email
            };

            var token = _authenticationService.GenerateToken(userViewModelOutput);
            return Ok(new
            {
                Token = token,
                User = userViewModelOutput
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerInput"></param>
        /// <returns>Register View Model</returns>
        [SwaggerResponse(statusCode: 200, description: "Authentication success", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Required Field", Type = typeof(FieldValidationViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Internal error", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("register")]
        [CustomModelStateValidation]
        public IActionResult Register(RegisterViewModelInput registerInput)
        {
            
            var UserData = new User();
            UserData.Login = registerInput.Login;
            UserData.Password = registerInput.Password;
            UserData.Email = registerInput.Email;
            _userRepository.Add(UserData);
            _userRepository.Commit();
            return Created("", registerInput);
        }
    }
}
