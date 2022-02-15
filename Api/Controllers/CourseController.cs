using CsharpApi.Models.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CsharpApi.Controllers
{
    [Route("api/v1/courses")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseInput"></param>
        /// <returns>Post a Course</returns>
        /// 
        [SwaggerResponse(statusCode: 201, description:"Sucesso ao cadastrar o curso")]
        [SwaggerResponse(statusCode: 401, description:"Falha ao cadastrar o curso")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostCourse(CourseViewModelInput courseInput)
        {
            var UserCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", courseInput);
        }

        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter os cursos")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            //var UserCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var courses = new List<CourseViewModelOutput>();

            courses.Add(new CourseViewModelOutput()
            {
                Login = "",
                Description = "First test",
                Name = "Teste Name"

            });
            
            return Ok(courses);
        }
    }
}
