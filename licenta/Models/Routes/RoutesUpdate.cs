using System;

namespace licenta.Models.Routes
{
    public class RoutesUpdate
    {
        public int RouteEmployeeId { get; set; }

        public int RouteCarId { get; set; }

        public string RouteDetails { get; set; }

        public DateTime ExecutionTime { get; set; }

        public string CollectedMoney { get; set; }

        public string SpentMoney { get; set; }

        public int KmNumber { get; set; }
    }
}
