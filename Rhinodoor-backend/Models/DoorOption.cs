using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rhinodoor_backend.Models
{
    public class DoorOption
    {
        [Key]
        public int Id { get; set; }

        public int DoorId { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public float Price { get; set; }

        public int ColorHex { get; set; }

        public int ColorRAL { get; set; }

        public List<Order> Orders { get; set; }

        public Door Door { get; set; }
    }
}