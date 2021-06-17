using System;

namespace Rhinodoor_backend.ViewModels.Admin.GetOrders
{
    public class ResponseViewModel
    {
        public int Id { get; set; }

        public string PlacedOn { get; set; }

        public string PlacedBy { get; set; }

        public string Status { get; set; }
    }
}