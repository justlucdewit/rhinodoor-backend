using System.Collections.Generic;

namespace Rhinodoor_backend.Services.Dtos
{
    public class DoorItemDto
    {
        public string DoorName { get; set; }

        public string DoorImage { get; set; }

        public List<int> ColorsHEX { get; set; }

        public List<int> ColorsRAL { get; set; }

        public List<DoorSizeDto> DoorSizes { get; set; }
    }
}