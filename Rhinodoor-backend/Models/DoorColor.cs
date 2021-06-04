using System.Collections.Generic;

namespace Rhinodoor_backend.Models
{
    public class DoorColor
    {
        public int Id { get; set; }

        public int DoorId { get; set; }

        public int ColorRAL { get; set; }

        public int ColorHEX { get; set; }

        public Door Door { get; set; }

        public List<Order> Orders { get; set; }
    }
}