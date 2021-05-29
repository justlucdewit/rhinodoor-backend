using System.Threading.Tasks;
using Rhinodoor_backend.Models;

namespace Rhinodoor_backend.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> PlaceOrder(Order order);
    }
}