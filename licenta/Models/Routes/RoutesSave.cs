using System;
using System.Collections.Generic;

namespace licenta.Models.Routes
{
    public class RoutesSave
    {
        public int RouteId { get; set; }

        public string RouteDeparture { get; set; }

        public string RouteDestination { get; set; }

        public int EmployeeId { get; set; }

        public int CarId { get; set; }

        public string RouteDetails { get; set; }

        public DateTime RoutePeriod { get; set; }
    }
}
