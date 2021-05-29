using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Rhinodoor_backend.AppExtensions;
using Rhinodoor_backend.Models;
using Rhinodoor_backend.Repositories.Dto.Door;
using Rhinodoor_backend.Repositories.Interfaces;

namespace Rhinodoor_backend.Repositories
{
    public class DoorRepository : IDoorRepository
    {
        private readonly DatabaseContextAbstract _dbContext;
        
        public DoorRepository(DatabaseContextAbstract dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Door> GetAll() =>
            _dbContext.Doors;

        public async Task<Door> Get(int doorId) =>
            await _dbContext.Doors
                .Where(door => door.Id == doorId)
                .FirstOrDefaultAsync();
    }
}