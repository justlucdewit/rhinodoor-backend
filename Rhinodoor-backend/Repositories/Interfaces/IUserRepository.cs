using System.Threading.Tasks;
using Rhinodoor_backend.Models;
using Rhinodoor_backend.Repositories.Dto.Door;

namespace Rhinodoor_backend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateClient(User user);

        Task<User> CreateAdmin(LoginDto login);
    }
}