using System;
using System.Collections.Generic;

namespace restapi_rocket_elevators.Models
{
    public partial class Map
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
