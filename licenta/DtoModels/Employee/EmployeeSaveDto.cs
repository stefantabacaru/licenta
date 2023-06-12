using System;
using System.ComponentModel.DataAnnotations;

namespace licenta.DtoModels.Employee
{
    public class EmployeeSaveDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name can't be longer then 50 char")]
        [MinLength(5, ErrorMessage = "Name can't be less then 5 char")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(50, ErrorMessage = "Password can't be longer then 50 char")]
        [MinLength(5, ErrorMessage = "Password can't be less then 5 char")]
        public string Password { get; set; } = string.Empty;

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
