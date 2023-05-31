using System;

namespace licenta.Models.Employee
{
    public class EmployeeUpdate
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string PhoneNumber { get; set; }

        public DateTime? EndDate { get; set; }

        public string Email { get; set; }

        public int WorkedDaysPerMonth { get; set; }
    }
}
