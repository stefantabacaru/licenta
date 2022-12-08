using System.ComponentModel.DataAnnotations;

namespace licenta.DtoModels.Customer
{
    public class CustomerSaveDto
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public int CustomerRouteId { get; set; }

        [Required]
        public string CustomerPhoneNumber { get; set; }

        [Required]
        public string CustomerEmail { get; set; }
    }
}
