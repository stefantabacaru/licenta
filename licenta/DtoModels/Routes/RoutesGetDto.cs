using System;

namespace licenta.DtoModels.Routes
{
    public class RoutesGetDto
    {
        public int EmployeeId { get; set; }

        public int CarId { get; set; }

        public int RoutesId { get; set; }

        public string RouteDetails { get; set; }

        public DateTime RoutePeriod { get; set; }

        public string CollectedMoney { get; set; }

        public string SpentMoney { get; set; }

        public int KmNumber { get; set; }
    }
}
