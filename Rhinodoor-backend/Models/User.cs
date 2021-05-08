using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rhinodoor_backend.Models
{
    public class User
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        
        public bool IsAdmin { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }
        
        public User CreatedByUser { get; set; }
        
        public User ModifiedByUser { get; set; }

        public Order Order { get; set; }
    }
}