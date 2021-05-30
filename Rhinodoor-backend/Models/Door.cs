using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rhinodoor_backend.Models
{
    public class Door
    {
        [Key]
        public int Id { get; set; }

        public string DoorName { get; set; }

        public string DoorImage { get; set; }

        public List<DoorOption> DoorOptions { get; set; }
        
        public List<Order> Orders { get; set; }

        public List<DoorColor> DoorColors { get; set; }
    }
}