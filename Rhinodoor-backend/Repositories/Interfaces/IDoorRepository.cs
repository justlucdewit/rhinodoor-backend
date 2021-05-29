using System.Linq;
using System.Threading.Tasks;
using Rhinodoor_backend.Models;

namespace Rhinodoor_backend.Repositories.Interfaces
{
    public interface IDoorRepository
    {
        IQueryable<Door> GetAll();

        Task<Door> Get(int doorId);
    }
}