using steptrans.Interfaces.Repositories;
using steptrans.Interfaces.Services;
using steptrans.Models.Employee;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace steptrans.Services
{
    public class EmployeeService : IEmployeeService

    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<int> CreateEmployee(EmployeeSave employeeSave)
        {

            ValidateStartDate(employeeSave.StartDate);


            return await employeeRepository.CreateEmployee(employeeSave).ConfigureAwait(false);
        }

        public Task<EmployeeSave> GetEmployees()
        {
            throw new NotImplementedException();
        }

        private void ValidateStartDate(DateTime startDate)
        {
            var date = DateTime.Today.AddDays(20);
            if (startDate > date)
                throw new ValidationException("You can not add an employee in the future.");
        } 
    }
}
