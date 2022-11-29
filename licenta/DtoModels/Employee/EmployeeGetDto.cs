using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace licenta.DtoModels.Employee
{
    public class EmployeeGetDto
    {
        public string FullName { get; set; }
        public DateTime StartDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int WorkingHours { get; set; }
        public string Role { get; set; }
       
    }
}
