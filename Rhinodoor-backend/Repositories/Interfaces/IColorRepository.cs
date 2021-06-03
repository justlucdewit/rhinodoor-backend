using System.Collections.Generic;
using System.Threading.Tasks;
using Rhinodoor_backend.Models;
using Rhinodoor_backend.Repositories.Dto.Door;

namespace Rhinodoor_backend.Repositories.Interfaces
{
    public interface IColorRepository
    {
        Task AddColorsAsync(List<ColorDto> colors);
    }
}