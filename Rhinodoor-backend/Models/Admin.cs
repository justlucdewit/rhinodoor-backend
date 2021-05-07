using System;

namespace Rhinodoor_backend.Models
{
    public class Admin
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}