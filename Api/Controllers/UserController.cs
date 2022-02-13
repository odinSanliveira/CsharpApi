using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.User;
using CsharpApi.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns>User status, user data and user token</returns>

        [SwaggerResponse(statusCode: 200, description:"Authentication success", Type=typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description:"Required Field", Type=typeof(FieldValidationViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description:"Internal error", Type=typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModelInput loginInput)
        {
            return Ok(loginInput);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerInput"></param>
        /// <returns></returns>
        [HttpPost]
        [Route ("register")]
        public IActionResult Register(RegisterViewModelInput registerInput)
        {
            return Created("", registerInput);
        }
    }
}
