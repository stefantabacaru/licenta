using System;
using System.ComponentModel.DataAnnotations;

namespace licenta.DtoModels.Routes
{
    public class RoutesSaveDto
    {
        [Required]
        public int RouteEmployeeId { get; set; }

        [Required]
        public int RouteCarId { get; set; }

        public string RouteDetails { get; set; } 

        [Required]
        public DateTime RoutePeriod {get; set; }
    }
}
