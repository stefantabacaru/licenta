using System;
using System.Collections.Generic;

namespace licenta.Models.Routes
{
    public class RoutesSave
    {
        public int RouteId { get; set; }

        public List<int> EmployeeId { get; set; }

        public List<int> CarId { get; set; }

        public string RouteDetails { get; set; }

        public DateTime ExecutionTime { get; set; }
    }
}
