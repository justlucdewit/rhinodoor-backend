using System.Collections.Generic;

namespace Rhinodoor_backend.ViewModels.Admin.NewDoor
{
    public class RequestViewModel
    {
        public string DoorName { get; set; }

        public string DoorImage { get; set; }

        public string Description { get; set; }

        public List<int> ColorsRAL { get; set; }

        public List<int> ColorsHex { get; set; }

        public List<DoorSizeViewModel> DoorSizes { get; set; }
    }
}