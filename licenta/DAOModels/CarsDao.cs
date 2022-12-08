using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace licenta.DAOModels
{
    public class CarsDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }

        [Required]
        public DateTime ManufacturingDate { get; set; }

        [Required]
        public string CarType { get; set; }

        [Required]
        public int SeatsNumber { get; set; }

        [Required]
        public string NumberPlate { get; set; }

        [Required]
        public int KmNumber { get; set; }

        public string CarHistory { get; set; }
       
        public ICollection<RepairsDao> Repairs { get; set; } = new List<RepairsDao>();

        public ICollection<CarsRouteDao> CarsRoutes { get; set; } = new List<CarsRouteDao>();
    }
}
