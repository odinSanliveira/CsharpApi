using api.web.mvc.Models.Course;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.web.mvc.Services
{
    public interface ICourseService
    {
        [Post("/api/v1/courses")]
        [Headers("Authorization: Bearer")]
        Task<CreateCourseViewModelOutput> Create(CreateCourseViewModelInput createCouseViewModelInput);

        [Get("/api/v1/courses")]
        [Headers("Authorization: Bearer")]
        Task<IList<ListCourseViewModelOutput>> List();

    }
}
