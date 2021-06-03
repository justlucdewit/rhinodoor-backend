using System.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Rhinodoor_backend.Repositories;
using Rhinodoor_backend.Repositories.Interfaces;
using Rhinodoor_backend.Services;
using Rhinodoor_backend.Services.Interfaces;

namespace Rhinodoor_backend.AppExtensions
{
    public class DependancyInjection
    {
        public DependancyInjection(ref IServiceCollection services)
        {
        }

        public static void Inject(ref IServiceCollection services)
        {
            // Door
            services.AddScoped<IDoorService, DoorService>();
            services.AddScoped<IDoorRepository, DoorRepository>();
            
            // Order
            services.AddScoped<IOrderRepository, OrderRepository>();
            
            // User
            services.AddScoped<IUserRepository, UserRepository>();
            
            // Color
            services.AddScoped<IColorRepository, ColorRepository>();
        }
    }
}