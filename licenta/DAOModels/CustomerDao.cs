using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace licenta.DAOModels
{
    public class CustomerDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

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
