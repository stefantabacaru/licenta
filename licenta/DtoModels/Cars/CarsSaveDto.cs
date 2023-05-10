using System;
using System.ComponentModel.DataAnnotations;

namespace licenta.DtoModels.Cars
{
    public class CarsSaveDto
    {
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

    }
}
