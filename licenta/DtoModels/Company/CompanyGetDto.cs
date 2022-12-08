using licenta.DtoModels.Employee;
using System.Collections.Generic;

namespace licenta.DtoModels.Company
{
    public class CompanyGetDto
    {
        public string Name { get; set; }

        public string Money { get; set; }

        public List<EmployeeGetDto> Employees { get; set; }

        public List<EmployeeGetDto> PastEmployees { get; set; }
    }
}
