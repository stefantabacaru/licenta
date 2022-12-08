using System.ComponentModel.DataAnnotations;

namespace licenta.DtoModels.Cars
{
    public class CarsUpdateDto
    {
        [Required]
        public int KmNumber { get; set; }
    }
}
