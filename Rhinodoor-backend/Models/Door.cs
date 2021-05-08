using System;

namespace Rhinodoor_backend.Models
{
    public class Door
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public string DoorName { get; set; }

        public string DoorImage { get; set; }

        public int DoorOptionId { get; set; }
    }
}