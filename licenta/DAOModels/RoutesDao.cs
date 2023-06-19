using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;

namespace licenta.DAOModels
{
    public class RoutesDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RouteId { get; set; }

        public int EmployeeId { get; set; }

        public EmployeeDao RouteEmployee { get; set; }

        public CarsDao RouteCar { get; set; }

        [Required]
        public int CarId { get; set; }

        public string RouteDeparture { get; set; }

        public string RouteDestination { get; set; }

        public string RouteDetails { get; set; }

        [Required]
        public DateTime RoutePeriod { get; set; }

        public string CollectedMoney { get; set; }

        public string SpentMoney { get; set; }

        public int KmNumber { get; set; }

        public int PassengersNumber { get; set; }

        public ICollection<CustomerDao> Passengers { get; set; } = new List<CustomerDao>();
    }
}
