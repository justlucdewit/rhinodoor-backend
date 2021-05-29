using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Rhinodoor_backend.Models;
using Rhinodoor_backend.Repositories.Interfaces;
using Rhinodoor_backend.Services.Dtos;
using Rhinodoor_backend.Services.Interfaces;

namespace Rhinodoor_backend.Services
{
    public class DoorService : IDoorService
    {
        private readonly IDoorRepository _doorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="doorRepository"></param>
        /// <param name="userRepository"></param>
        /// <param name="orderRepository"></param>
        public DoorService(
            IDoorRepository doorRepository,
            IUserRepository userRepository,
            IOrderRepository orderRepository)
        {
            _doorRepository = doorRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }
        
        /// <summary>
        /// Get list of all doors (non detailed information)
        /// </summary>
        /// <returns>list of door info, without much detail</returns>
        public async Task<List<DoorDto>> GetAll()
        {
            // Retrieve all of the door database objects
            var doors = await _doorRepository
                .GetAll()
                .ToListAsync();
            
            // Map them to a DTO and return that
            return doors.Select(door => new DoorDto
            {
                DoorName = door.DoorName,
                DoorImage = door.DoorImage
            }).ToList();
        }
        
        /// <summary>
        /// Places an order
        /// </summary>
        /// <param name="order"></param>
        public async Task PlaceOrder(OrderDto order)
        {
            // Register the client
            var dbUser = await _userRepository.CreateClient(new User
            {
                Name = order.ClientName,
                Address = order.ClientAddress,
                City = order.ClientCity,
                PostalCode = order.ClientPostalCode,
                PhoneNumber = order.ClientPhoneNumber,
                Email = order.ClientEmail,
                IsAdmin = false,
                UserName = "",
                PasswordHash = "",
            });

            // Register the order
            _orderRepository.PlaceOrder(new Order
            {
                PlacedOn = DateTime.UtcNow,
                PlacedByUser = dbUser,
                DoorId = order.DoorId,
                DoorOptionId = order.DoorOptionId
            });
        }
    }
}