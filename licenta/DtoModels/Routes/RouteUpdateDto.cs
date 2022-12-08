using System;
using System.Collections.Generic;

namespace licenta.DtoModels.Routes
{
    public class RouteUpdateDto
    {
        public List<int> EmployeeId { get; set; }

        public List<int> CarId { get; set; }

        public string MoneyCollected { get; set; }

        public string MoneySpent { get; set; }

        public int KmNumber { get; set; }

        public int CustomersNumber { get; set; }

        public string RouteDetails { get; set; }

        public DateTime RoutePeriod { get; set; }
    }
}
