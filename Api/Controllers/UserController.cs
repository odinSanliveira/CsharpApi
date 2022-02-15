using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Models.User;
using CsharpApi.Business.Entities;
using CsharpApi.Filters;
using CsharpApi.Infrastructure.Data;
using CsharpApi.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        [SwaggerResponse(statusCode: 200, description: "Authentication success", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Required Field", Type = typeof(FieldValidationViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Internal error", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("login")]
        [CustomModelStateValidation]
        public IActionResult Login(LoginViewModelInput loginInput)
        {
            var userViewModelOutput = new UserViewModelOutput()
            {
                Code = 1,
                Login = "odinSantos",
                Email = "odin@gmail.com"
            };
            var secret = Encoding.ASCII.GetBytes("MzfsT&d9gprP>!9$Es(X!5g@;ef!5sbk:jH\\2.}8ZP'qY#7");
            //var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("MzfsT&d9gprP>!9$Es(X!5g@;ef!5sbk:jH\\2.}8ZP'qY#7").Value);
            var symmetricSecyrityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userViewModelOutput.Code.ToString()),
                    new Claim(ClaimTypes.Name, userViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, userViewModelOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecyrityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescription);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);
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
            var OptionsBuilder = new DbContextOptionsBuilder<CourseDatabaseContext>();
            OptionsBuilder.UseSqlServer("Server=localhost;Database=API_COURSE;Trusted_Connection=True;");
            CourseDatabaseContext context = new CourseDatabaseContext(OptionsBuilder.Options);
            var awaitMigrations = context.Database.GetPendingMigrations();
            if(awaitMigrations.Count() > 0)
            {
                context.Database.Migrate();
            }
            var UserData = new User();
            UserData.Login = registerInput.Login;
            UserData.Password = registerInput.Password;
            UserData.Email = registerInput.Email;
            context.DbUser.Add(UserData);
            context.SaveChanges();

            return Created("", registerInput);
        }
    }
}
