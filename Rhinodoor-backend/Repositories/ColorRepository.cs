using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rhinodoor_backend.AppExtensions;
using Rhinodoor_backend.Models;
using Rhinodoor_backend.Repositories.Dto.Door;
using Rhinodoor_backend.Repositories.Interfaces;

namespace Rhinodoor_backend.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private readonly DatabaseContextAbstract _dbContext;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public ColorRepository(DatabaseContextAbstract dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// Add Colors Async
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public async Task AddColorsAsync(List<ColorDto> colors)
        {
            var mappedColors = colors.Select(color => new DoorColor
            {
                ColorHEX = color.ColorHEX,
                ColorRAL = color.ColorRAL,
                DoorId = color.DoorId
            });

            await _dbContext.DoorColors.AddRangeAsync(mappedColors);

            await _dbContext.SaveChangesAsync();
        }
    }
}