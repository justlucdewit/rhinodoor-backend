using System.Threading.Tasks;
using Rhinodoor_backend.AppExtensions;
using Rhinodoor_backend.Models;
using Rhinodoor_backend.Repositories.Interfaces;

namespace Rhinodoor_backend.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContextAbstract _dbContext;
        
        public OrderRepository(DatabaseContextAbstract dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> PlaceOrder(Order order)
        {
            var dbOrder = await _dbContext.Orders.AddAsync(order);

            return dbOrder.Entity;
        }
    }
}