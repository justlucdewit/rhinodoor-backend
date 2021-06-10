using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Rhinodoor_backend.Models;
using Rhinodoor_backend.Repositories.Dto.Door;
using Rhinodoor_backend.Repositories.Interfaces;
using Rhinodoor_backend.Services.Dtos;
using Rhinodoor_backend.Services.Interfaces;
using DoorDto = Rhinodoor_backend.Services.Dtos.DoorDto;

namespace Rhinodoor_backend.Services
{
    public class DoorService : IDoorService
    {
        private readonly IDoorRepository _doorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IColorRepository _colorRepository;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="doorRepository"></param>
        /// <param name="userRepository"></param>
        /// <param name="orderRepository"></param>
        public DoorService(
            IDoorRepository doorRepository,
            IUserRepository userRepository,
            IOrderRepository orderRepository,
            IColorRepository colorRepository)
        {
            _doorRepository = doorRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _colorRepository = colorRepository;
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
            await _orderRepository.PlaceOrder(new Order
            {
                PlacedOn = DateTime.UtcNow,
                PlacedByUser = dbUser,
                DoorId = order.DoorId,
                DoorOptionId = order.DoorOptionId,
                DoorColorId = order.DoorColorId
            });
        }

        /// <summary>
        /// Put a new door into the database
        /// </summary>
        /// <param name="doorItem"></param>
        /// <returns></returns>
        public async Task CreateNewDoor(DoorItemDto doorItem)
        {
            var dbDoor = await _doorRepository.CreateNewDoor(new Repositories.Dto.Door.DoorDto
            {
                DoorImage = doorItem.DoorImage,
                DoorName = doorItem.DoorName
            });

            await _doorRepository.CreateDoorOptions(dbDoor.Id, doorItem.DoorSizes.Select(doorSize => new DoorOptionDto
            {
                Height = doorSize.Height,
                Price = doorSize.Price,
                Width = doorSize.Width
            }).ToList());

            var colors = doorItem.ColorsHEX.Select((hex, index) => new ColorDto
            {
                ColorHEX = hex,
                ColorRAL = doorItem.ColorsRAL[index],
                DoorId = dbDoor.Id
            }).ToList();

            await _colorRepository.AddColorsAsync(colors);
        }

        public async Task CreateNewUser(Rhinodoor_backend.Services.Dtos.LoginDto loginItem)
        {
            
        }
    }
}