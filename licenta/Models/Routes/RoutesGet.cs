using System;
using System.Collections.Generic;

namespace licenta.Models.Routes
{
    public class RoutesGet
    {
        public int RouteId { get; set; }

        public int EmployeeId { get; set; }

        public int CarId { get; set; }

        public string RouteDetails { get; set; }

        public DateTime RoutePeriod { get; set; }

        public string CollectedMoney { get; set; }

        public string SpentMoney { get; set; }

        public int KmNumber { get; set; }
    }
}
