using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public DoorRepository(DatabaseContextAbstract dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// Get all Doors
        /// </summary>
        /// <returns></returns>
        public IQueryable<Door> GetAll() =>
            _dbContext.Doors;
        
        /// <summary>
        /// Get specific door
        /// </summary>
        /// <param name="doorId"></param>
        /// <returns></returns>
        public async Task<Door> Get(int doorId) =>
            await _dbContext.Doors
                .Where(door => door.Id == doorId)
                .FirstOrDefaultAsync();

        
        /// <summary>
        /// Remove a door by id
        /// </summary>
        /// <param name="doorId"></param>
        /// <returns></returns>
        public async Task RemoveDoorAsync(int doorId, bool deleteOrders)
        {
            // Remove orders (if necessary and if signaled too)
            var ordered = _dbContext.Orders.Any(x => x.DoorId == doorId);

            if (ordered && !deleteOrders)
                throw new Exception("This door orders and should not be deleted");
            
            if (ordered)
            {
                var orders = _dbContext.Orders.Where(x => x.DoorId == doorId);
                
                _dbContext.Orders.RemoveRange(orders);
            }
            
            // Remove the door options
            var doorOptions = _dbContext.DoorOptions
                .Where(x => x.DoorId == doorId);
            
            _dbContext.DoorOptions
                .RemoveRange(doorOptions);
            
            // Remove the door colors
            var doorColors = _dbContext.DoorColors
                .Where(x => x.DoorId == doorId);
            

            _dbContext.DoorColors
                .RemoveRange(doorColors);
            
            // Remove the door
            var dbDoor = await _dbContext.Doors
                .FirstOrDefaultAsync(x => x.Id == doorId);
            
            _dbContext.Doors
                .Remove(dbDoor);
            
            // Save
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Create a new door
        /// </summary>
        /// <param name="door"></param>
        /// <returns></returns>
        public async Task<Door> CreateNewDoor(DoorDto door)
        {
            // Register the new door
            var dbDoor = await _dbContext.Doors.AddAsync(new Door
            {
                DoorImage = door.DoorImage,
                DoorName = door.DoorName,
                DoorDescription = door.DoorDescription
            });
            
            await _dbContext.SaveChangesAsync();
            
            // Return it
            return dbDoor.Entity;
        }

        /// <summary>
        /// Create door options
        /// </summary>
        /// <param name="doorId"></param>
        /// <param name="doorOptions"></param>
        /// <returns></returns>
        public async Task CreateDoorOptions(int doorId, List<DoorOptionDto> doorOptions)
        {
            // Map the new door options
            var DoorSizes = doorOptions.Select(option => new DoorOption
            {
                DoorId = doorId,
                Height = option.Height,
                Width = option.Width,
                Price = option.Price
            });

            // Create the new door options
            await _dbContext.DoorOptions.AddRangeAsync(DoorSizes);
            
            // Save the db
            await _dbContext.SaveChangesAsync();
        }
    }
}