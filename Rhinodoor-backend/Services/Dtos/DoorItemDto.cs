using System.Collections.Generic;

namespace Rhinodoor_backend.Services.Dtos
{
    public class DoorItemDto
    {
        public string DoorName { get; set; }

        public string DoorImage { get; set; }

        public List<string> ColorsHex { get; set; }

        public List<DoorSizeDto> DoorSizes { get; set; }
    }
}