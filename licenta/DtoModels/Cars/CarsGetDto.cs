using System;
using System.ComponentModel.DataAnnotations;

namespace licenta.DtoModels.Cars
{
    public class CarsGetDto
    {       
            public int CarId { get; set; }

            public DateTime ManufacturingDate { get; set; }

            public string CarType { get; set; }

            public int SeatsNumber { get; set; }

            public string NumberPlate { get; set; }

            public int KmNumber { get; set; }

            public string CarHistory { get; set; }
     }
}
