using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace licenta.Models.Cars
{
    public class CarsSave
    {
        public int CarsId { get; set; }

        public string ManufacturingDate { get; set; }   
        public string CarType { get; set; }
        public int SeatsNumber { get; set; }
        public string NumberPlate { get; set; }
        public int KmNumber { get; set; }
        public string CarHistory { get; set; }
    }
}
