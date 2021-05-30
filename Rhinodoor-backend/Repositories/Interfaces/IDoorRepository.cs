using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rhinodoor_backend.Models;
using Rhinodoor_backend.Repositories.Dto.Door;

namespace Rhinodoor_backend.Repositories.Interfaces
{
    public interface IDoorRepository
    {
        IQueryable<Door> GetAll();

        Task<Door> Get(int doorId);
        
        Task<Door> CreateNewDoor(DoorDto door);

        Task CreateDoorOptions(int doorId, List<DoorOptionDto> doorOptions);
    }
}