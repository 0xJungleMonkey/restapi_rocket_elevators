using System;
using System.Collections.Generic;

namespace restapi_rocket_elevators.Models
{
    public partial class Elevator
    {
        public long? ColumnId { get; set; }
        public long Id { get; set; }
        public int? SerialNumber { get; set; }
        public string? Model { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public DateTime CommisionDate { get; set; }
        public DateTime LastInspectionDate { get; set; }
        public string? InspectionCert { get; set; }
        public string? Information { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // public virtual Column? Column { get; set; }
    }
}
