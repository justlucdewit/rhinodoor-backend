using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("/admin/new-door")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> NewDoor([FromRoute] string username, [FromRoute] string password, [FromBody] ViewModels.Admin.NewDoor.RequestViewModel request)
        {
            
            return Ok();
        }
    }
}