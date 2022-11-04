using System;
using System.ComponentModel.DataAnnotations;

namespace steptrans.DtoModels.Employee
{
    public class EmployeeSaveDto
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required, MaxLength(15)]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
