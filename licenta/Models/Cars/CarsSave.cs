using System;

namespace licenta.Models.Cars
{
    public class CarsSave
    {
        public int CarsId { get; set; }

        public DateTime ManufacturingDate { get; set; }   

        public string CarType { get; set; }

        public int SeatsNumber { get; set; }

        public string NumberPlate { get; set; }

        public int KmNumber { get; set; }

        public string CarHistory { get; set; }
    }
}
