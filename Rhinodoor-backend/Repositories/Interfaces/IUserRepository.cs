using System.Threading.Tasks;
using Rhinodoor_backend.Models;

namespace Rhinodoor_backend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateClient(User user);
    }
}