using api.web.mvc.Models.Users;
using Refit;
using System.Threading.Tasks;

namespace api.web.mvc.Services
{
    public interface IUserService
    {
        [Post("/api/v1/user/register")]
        Task<CreateUserViewModelInput> Register(CreateUserViewModelInput CreatingUser);
    }
}
