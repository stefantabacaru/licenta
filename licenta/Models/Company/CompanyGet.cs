using licenta.Models.Employee;
using System.Collections.Generic;

namespace licenta.Models.Company
{
    public class CompanyGet
    {
        public string Name { get; set; }

        public string Money { get; set; }

        public List<EmployeeGet> Employees { get; set; }

        public List<EmployeeGet> PastEmployees { get; set; }
    }
}
