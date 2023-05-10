using System;

namespace licenta.Models.Employee
{
    public class EmployeeSave
    {
        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public DateTime StartDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
