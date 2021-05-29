using System.Threading.Tasks;
using Rhinodoor_backend.AppExtensions;
using Rhinodoor_backend.Models;

namespace Rhinodoor_backend.Repositories.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContextAbstract _dbContext;
        
        public UserRepository(DatabaseContextAbstract dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<User> CreateClient(User user)
        {
            var dbUser = await _dbContext.Users.AddAsync(user);

            return dbUser.Entity;
        }
    }
}