using System;
using System.Collections.Generic;

namespace licenta.Models.Routes
{
    public class RoutesUpdate
    {
        public string RouteDetails { get; set; }

        public DateTime RoutePeriod { get; set; }

        public string CollectedMoney { get; set; }

        public string SpentMoney { get; set; }

        public int PassengersNumber { get; set; }

        public int KmNumber { get; set; }
    }
}
