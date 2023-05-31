using System;

namespace licenta.Models.Employee
{
    public class EmployeeSave
    {
        public string Username { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public DateTime StartDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
