using System;

namespace licenta.DtoModels.Routes
{
    public class RouteUpdateDto
    {
        public int RouteEmployeeId { get; set; }

        public int RouteCarId { get; set; }

        public string MoneyCollected { get; set; }

        public string MoneySpent { get; set; }

        public int KmNumber { get; set; }

        public int CustomersNumber { get; set; }

        public string RouteDetails { get; set; }

        public DateTime RoutePeriod { get; set; }
    }
}
