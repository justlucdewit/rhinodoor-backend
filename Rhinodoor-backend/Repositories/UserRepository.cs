using System.Threading.Tasks;
using Rhinodoor_backend.AppExtensions;
using Rhinodoor_backend.Models;
using Rhinodoor_backend.Repositories.Dto.Door;

namespace Rhinodoor_backend.Repositories.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContextAbstract _dbContext;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public UserRepository(DatabaseContextAbstract dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// Create a new client
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> CreateClient(User user)
        {
            var dbUser = await _dbContext.Users.AddAsync(user);
            
            await _dbContext.SaveChangesAsync();

            return dbUser.Entity;
        }

        public async Task CreateAdmin(LoginDto login)
        {
            
        }
    }
}