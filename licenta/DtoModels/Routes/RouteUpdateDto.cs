using System;
using System.Collections.Generic;

namespace licenta.DtoModels.Routes
{
    public class RouteUpdateDto
    {
        public string CollectedMoney { get; set; }

        public string SpentMoney { get; set; }

        public int KmNumber { get; set; }

        public int PassengersNumber { get; set; }

        public string RouteDetails { get; set; }

        public DateTime RoutePeriod { get; set; }
    }
}
