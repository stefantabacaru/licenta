using System;
using System.ComponentModel.DataAnnotations;

namespace licenta.DtoModels.Employee
{
    public class EmployeeUpdateDto
    {
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;

        [MaxLength(15)]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public int WorkedDaysPerMonth { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
