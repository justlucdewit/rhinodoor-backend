using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
        
        /// <summary>
        /// Create a new admin with login info
        /// </summary>
        /// <param name="login">Login info (password & username)</param>
        /// <returns>User object from database</returns>
        public async Task<User> CreateAdmin(LoginDto login)
        {
            // Generate randomized salt value
            var salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);
            
            // Hash the password
            var passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: login.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // Create entry
            var dbUser = await _dbContext.Users.AddAsync(new User
            {
                PasswordHash = passwordHash,
                PasswordSalt = Convert.ToBase64String(salt),
                UserName = login.UserName
            });
            
            // Save the changes
            await _dbContext.SaveChangesAsync();
            
            // Return the newly created db entity
            return dbUser.Entity;
        }
    }
}