using System;

namespace Rhinodoor_backend.Models
{
    public class DoorPrices
    {
        public int Id { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public float Price { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}