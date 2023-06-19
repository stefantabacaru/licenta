using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace licenta.DAOModels
{
    public class EmployeeDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name can't be longer then 50 char")]
        [MinLength(5, ErrorMessage = "Name can't be less then 5 char")]
        public string Username { get; set; } = string.Empty;

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required, MaxLength(15)]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public int WorkedDaysPerMonth { get; set; }

        [Required]
        public string Role { get; set; }

        public ICollection<RoutesDao> EmployeeRoutes { get; set; } = new List<RoutesDao>();

        public ICollection<RepairsDao> Repairs { get; set; } = new List<RepairsDao>();

        public CompanyDao Company { get; set; }

        public int CompanyId { get; set; }
    }
}
