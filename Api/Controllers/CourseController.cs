using CsharpApi.Business.Entities;
using CsharpApi.Business.Repositories;
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
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseInput"></param>
        /// <returns>Post a Course</returns>
        /// 
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar o curso")]
        [SwaggerResponse(statusCode: 401, description: "Falha ao cadastrar o curso")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CourseViewModelInput courseInput)
        {
            Course course = new Course();
            course.Title = courseInput.Title;
            course.Description = courseInput.Description;
            var UserCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            course.UserCode = UserCode;
            _courseRepository.AddCourse(course);
            _courseRepository.Commit();
            return Created("", courseInput);
        }

        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter os cursos")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {

            var UserCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            //var courses = new List<CourseViewModelOutput>();
            var courses = _courseRepository.GetByUser(UserCode)
                .Select(s => new CourseViewModelOutput()
                {
                    Login = s.User.Login,
                    Title = s.Title,
                    Description = s.Description
                }) ;

            return Ok(courses);
        }
    }
}
