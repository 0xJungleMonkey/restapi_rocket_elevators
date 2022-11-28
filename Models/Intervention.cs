using System;
using System.Collections.Generic;

namespace restapi_rocket_elevators.Models
{
    public partial class Intervention
    {
        public long Id { get; set; }
        public string? Author { get; set; }
        public int? CustomerId { get; set; }
        public int? BuildingId { get; set; }
        public int? BatteryId { get; set; }
        public int? ColumnId { get; set; }
        public int? ElevatorId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? StartDatetime { get; set; }
        public DateTime? EndDatetime { get; set; }
        public string? Result { get; set; }
        public string? Report { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
