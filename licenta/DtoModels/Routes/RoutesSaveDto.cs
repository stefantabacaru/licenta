using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace licenta.DtoModels.Routes
{
    public class RoutesSaveDto
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int CarId { get; set; }

        public string RouteDetails { get; set; }

        public string RouteDeparture { get; set; }

        public string RouteDestination { get; set; }

        [Required]
        public DateTime RoutePeriod {get; set; }
    }
}
