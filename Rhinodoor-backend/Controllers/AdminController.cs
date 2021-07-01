using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rhinodoor_backend.Services.Dtos;
using Rhinodoor_backend.Services.Interfaces;

namespace Rhinodoor_backend.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IDoorService _doorService;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public AdminController(IDoorService doorService)
        {
            _doorService = doorService;
        }
        
        /// <summary>
        /// Create a new door to be sold
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("admin/new-door")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> NewDoor([FromRoute] string username, [FromRoute] string password, [FromBody] ViewModels.Admin.NewDoor.RequestViewModel request)
        {
            await _doorService.CreateNewDoor(new DoorItemDto
            {
                ColorsHEX = request.ColorsHex,
                ColorsRAL = request.ColorsRAL,
                DoorImage = request.DoorImage,
                DoorName = request.DoorName,
                DoorSizes = request.DoorSizes.Select(size => new DoorSizeDto
                {
                  Height = size.Height,
                  Width = size.Width,
                  Price = size.Price
                }).ToList()
            });
            
            return Ok();
        }
        
        /// <summary>
        /// Create a new admin account with login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("admin/new-admin")]
        public async Task<ActionResult> NewAdmin([FromBody] ViewModels.Admin.NewAdmin.RequestViewModel request)
        {
            await _doorService.CreateNewAdmin(new LoginDto
            {
                UserName = request.UserName,
                Password = request.Password
            });
            
            return Ok();
        }
        
        /// <summary>
        /// Delete a door
        /// </summary>
        /// <param name="doorId"></param>
        /// <returns></returns>
        [HttpDelete("admin/door/{doorId:int}/{deleteOrders:bool}")]
        public async Task<ActionResult> DeleteDoor([FromRoute] int doorId, [FromRoute] bool deleteOrders)
        {
            await _doorService.RemoveDoorAsync(doorId, deleteOrders);
            
            return Ok();
        }
        
        /// <summary>
        /// Validate a login code
        /// </summary>
        /// <returns></returns>
        [HttpPost("admin/validate-login")]
        public async Task<ActionResult> ValidateLogin([FromBody] ViewModels.Admin.ValidateLogin.RequestViewModel request)
        {
            var result = await _doorService.ValidateLogin(new LoginDto
            {
                UserName = request.UserName,
                Password = request.Password
            });

            return result
                ? Ok()
                : Unauthorized();
        }
        
        /// <summary>
        /// Gets an overview of all orders
        /// </summary>
        /// <returns></returns>
        [HttpGet("/admin/orders")]
        public async Task<ActionResult> GetOrders()
        {
            var orders = await _doorService.GetOrderOverview();

            var responseViewModel = orders.Select(order => new ViewModels.Admin.GetOrders.ResponseViewModel
            {
                Status = order.Status,
                Id = order.Id,
                PlacedBy = order.PlacedBy,
                PlacedOn = order.PlacedOn
            }).ToList();
            
            return Ok(responseViewModel);
        }
    }
}