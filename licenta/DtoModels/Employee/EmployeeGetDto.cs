using System;

namespace licenta.DtoModels.Employee
{
    public class EmployeeGetDto
    {
        public string Username { get; set; } = string.Empty;

        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int WorkingHours { get; set; }

        public string Role { get; set; }
    }
}
