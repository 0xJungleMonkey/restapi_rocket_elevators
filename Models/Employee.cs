using System;
using System.Collections.Generic;

namespace restapi_rocket_elevators.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Batteries = new HashSet<Battery>();
        }

        public long? UserId { get; set; }
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
    }
}
