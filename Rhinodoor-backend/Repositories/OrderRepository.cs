using System.Threading.Tasks;
using Rhinodoor_backend.AppExtensions;
using Rhinodoor_backend.Models;
using Rhinodoor_backend.Repositories.Interfaces;

namespace Rhinodoor_backend.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContextAbstract _dbContext;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public OrderRepository(DatabaseContextAbstract dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> PlaceOrder(Order order)
        {
            var dbOrder = await _dbContext.Orders.AddAsync(order);
            
            await _dbContext.SaveChangesAsync();

            return dbOrder.Entity;
        }
    }
}