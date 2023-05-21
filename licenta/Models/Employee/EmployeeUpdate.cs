using System;

namespace licenta.Models.Employee
{
    public class EmployeeUpdate
    {
        public string PhoneNumber { get; set; }

        public DateTime? EndDate { get; set; }

        public string Email { get; set; }

        public int WorkedDaysPerMonth { get; set; }
    }
}
