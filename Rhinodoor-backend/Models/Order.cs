using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rhinodoor_backend.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public int DoorId { get; set; }

        public User CreatedByUser { get; set; }
        
        public User ModifiedByUser { get; set; }
        
        public Door Door { get; set; }
    }
}