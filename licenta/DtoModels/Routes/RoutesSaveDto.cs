using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace licenta.DtoModels.Routes
{
    public class RoutesSaveDto
    {
        [Required]
        public List<int> EmployeeId { get; set; }

        [Required]
        public List<int> CarId { get; set; }

        public string RouteDetails { get; set; } 

        [Required]
        public DateTime RoutePeriod {get; set; }
    }
}
