using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rhinodoor_backend.Services.Dtos;
using Rhinodoor_backend.Services.Interfaces;

namespace Rhinodoor_backend.Controllers
{
    [ApiController]
    [Route("[controller]/{username}/{password}/")]
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
        [HttpPost("/new-door")]
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
        
        [HttpPost("/new-admin")]
        public async Task<ActionResult> NewAdmin()
        {
            return Ok();
        }
    }
}