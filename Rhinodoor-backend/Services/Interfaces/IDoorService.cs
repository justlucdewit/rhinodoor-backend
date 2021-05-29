using System.Collections.Generic;
using System.Threading.Tasks;
using Rhinodoor_backend.Services.Dtos;

namespace Rhinodoor_backend.Services.Interfaces
{
    public interface IDoorService
    {
        Task<List<DoorDto>> GetAll();

        Task PlaceOrder(OrderDto order);
    }
}