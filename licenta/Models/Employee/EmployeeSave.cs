using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace steptrans.Models.Employee
{
    public class EmployeeSave
    {
       
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name can not be longer than 50 char.")]
        public string FullName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required, MaxLength(15, ErrorMessage = "Phone number can not be longer than 15 char.")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
