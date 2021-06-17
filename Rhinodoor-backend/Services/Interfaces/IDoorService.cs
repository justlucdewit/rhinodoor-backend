using System.Collections.Generic;
using System.Threading.Tasks;
using Rhinodoor_backend.Services.Dtos;

namespace Rhinodoor_backend.Services.Interfaces
{
    public interface IDoorService
    {
        Task<List<DoorDto>> GetAll();

        Task PlaceOrder(OrderDto order);

        Task CreateNewDoor(DoorItemDto doorItem);

        Task CreateNewAdmin(Rhinodoor_backend.Services.Dtos.LoginDto loginItem);

        Task RemoveDoorAsync(int doorId, bool deleteOrders);

        Task<bool> ValidateLogin(LoginDto login);

        Task<List<OrderOverviewDto>> GetOrderOverview();
    }
}