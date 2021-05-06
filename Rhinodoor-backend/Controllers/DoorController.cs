using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rhinodoor_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoorController : ControllerBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DoorController()
        {
            
        }
        
        /// <summary>
        /// Retrieves all door settings and returns that to the frontend
        /// </summary>
        /// <returns>A list of all the door settings</returns>
        [HttpGet("")]
        public async Task<ActionResult> GetAll()
        {
            var response = new List<ViewModels.Doors.GetAll.ResponseViewModel>
            {
                
            };
            
            return new JsonResult(response);
        }
    }
}