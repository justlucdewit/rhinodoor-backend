using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rhinodoor_backend.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime PlacedOn { get; set; }

        public int PlacedBy { get; set; }

        public int DoorId { get; set; }

        public int DoorOptionId { get; set; }

        public virtual User PlacedByUser { get; set; }

        public virtual Door Door { get; set; }

        public virtual DoorOption DoorOption { get; set; }
    }
}