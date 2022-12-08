using System;

namespace licenta.Models.Routes
{
    public class RoutesSave
    {
        public int RouteId { get; set; }

        public int RouteEmployeeId { get; set; }

        public int RouteCarId { get; set; }

        public string RouteDetails { get; set; }

        public DateTime ExecutionTime { get; set; }
    }
}
