using System;
using System.Collections.Generic;

namespace licenta.Models.Routes
{
    public class RoutesUpdate
    {
        public List<int> EmployeeId { get; set; }

        public List<int> CarId { get; set; }

        public string RouteDetails { get; set; }

        public DateTime ExecutionTime { get; set; }

        public string CollectedMoney { get; set; }

        public string SpentMoney { get; set; }

        public int KmNumber { get; set; }
    }
}
