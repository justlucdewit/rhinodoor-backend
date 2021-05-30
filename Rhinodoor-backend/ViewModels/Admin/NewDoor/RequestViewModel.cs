using System.Collections.Generic;

namespace Rhinodoor_backend.ViewModels.Admin.NewDoor
{
    public class RequestViewModel
    {
        public string DoorName { get; set; }

        public string DoorImage { get; set; }

        public List<string> ColorsHex { get; set; }

        public List<DoorSizeViewModel> DoorSizes { get; set; }
    }
}