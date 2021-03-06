using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rhinodoor_backend.Repositories;
using Rhinodoor_backend.Services.Dtos;
using Rhinodoor_backend.Services.Interfaces;

namespace Rhinodoor_backend.Controllers
{
    [ApiController]
    public class DoorController : ControllerBase
    {
        private readonly IDoorService _doorService;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="doorService"></param>
        public DoorController(IDoorService doorService)
        {
            _doorService = doorService;
        }
        
        /// <summary>
        /// Retrieves basic info of all the doors and returns that in an HTTP ok
        /// </summary>
        /// <returns>A list of all the door data</returns>
        [HttpGet("door/all")]
        [ProducesResponseType(200, Type=typeof(ViewModels.Doors.GetAll.ResponseViewModel))]
        public async Task<ActionResult> GetAll()
        {
            var doors = await _doorService.GetAll();

            var response = doors.Select(door => new ViewModels.Doors.GetAll.ResponseViewModel
            {
                DoorName = door.DoorName,
                DoorImage = door.DoorImage,
                DoorId = door.DoorId
            }).ToList();
            
            return new JsonResult(response);
        }
        
        /// <summary>
        /// Order door
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("door/order")]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> OrderDoor([FromBody] ViewModels.Doors.OrderDoor.RequestViewModel request)
        {
            await _doorService.PlaceOrder(new OrderDto
            {
                ClientAddress = request.ClientAddress,
                ClientCity = request.ClientCity,
                ClientEmail = request.ClientEmail,
                ClientName = request.ClientName,
                ClientPhoneNumber = request.ClientPhoneNumber,
                ClientPostalCode = request.ClientPostalCode,
                DoorId = request.DoorId,
                DoorOptionId = request.DoorOptionId,
                DoorColorId = request.DoorColorId
            });
            
            return Ok();
        }
        
        [HttpGet("door/{doorId:int}")]
        [Consumes("application/json")]
        [ProducesResponseType(200, Type = typeof(ViewModels.Doors.GetDoor.RequestViewModel))]
        public async Task<ActionResult> GetDoor([FromRoute] int doorId)
        {
            var doorDetails = await _doorService.GetDoorDetails(doorId);
            
            return Ok(new ViewModels.Doors.GetDoor.RequestViewModel
            {
                Name = doorDetails.Name,
                Description = doorDetails.Description
            });
        }
    }
}