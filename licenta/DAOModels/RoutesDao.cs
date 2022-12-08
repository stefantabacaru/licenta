using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace licenta.DAOModels
{
    public class RoutesDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RouteId { get; set; }

        public EmployeeDao RouteEmployee { get; set; }

        [Required]
        public int RouteEmployeeId { get; set; }

        public CarsDao RouteCar { get; set; }

        [Required]
        public int RouteCarId { get; set; }

        public string RouteDetails { get; set; }

        [Required]
        public DateTime RoutePeriod { get; set; }

        public string CollectedMoney { get; set; }

        public string SpentMoney { get; set; }

        public int KmNumber { get; set; }
    }
}
