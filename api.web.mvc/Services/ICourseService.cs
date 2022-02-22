using api.web.mvc.Models.Course;
using Refit;
using System.Threading.Tasks;

namespace api.web.mvc.Services
{
    public interface ICourseService
    {
        [Post("/api/v1/courses")]
        Task<CreateCourseViewModelOutput> Create(CreateCourseViewModelInput createCouseViewModelInput);

    }
}
