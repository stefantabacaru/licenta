using licenta.Interfaces.Services;
using licenta.Models.Employee;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using licenta.DAOModels;
using System.Linq;

namespace licenta.Services
{
    public class EmployeeService : IEmployeeService

    {
        private Context.ContextDB _context;
        private readonly IMapper mapper;

        public EmployeeService(Context.ContextDB context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> CreateEmployee(EmployeeSave employeeSave)
        {
            ValidateStartDate(employeeSave.StartDate);

            var employeeSaveDao = mapper.Map<EmployeeDao>(employeeSave);
            _context.Employees.Add(employeeSaveDao);
            _context.SaveChanges();
            return employeeSaveDao.EmployeeId;
        }

        public async Task DeleteEmployeeById(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.EmployeeId == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public async Task<EmployeeGet> GetEmployeeById(int id)
        {
            return mapper.Map<EmployeeGet>(_context.Employees.SingleOrDefault(x => x.EmployeeId == id));
        }

        public async Task<List<EmployeeGet>> GetEmployees()
        {
            return mapper.Map<List<EmployeeGet>>(_context.Employees.ToList());
        }

        public async Task UpdateEmployee(EmployeeUpdate employeeUpdate, int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.EmployeeId == id);
            if (employeeUpdate != null)
            {
                employee.PhoneNumber = employeeUpdate.PhoneNumber;
                employee.Email = employeeUpdate.Email;
                employee.WorkedDaysPerMonth = employeeUpdate.WorkedDaysPerMonth;
                employee.EndDate = employeeUpdate.EndDate;

                _context.Employees.Update(employee);
                _context.SaveChanges();
            }
        }
 
        private void ValidateStartDate(DateTime startDate)
        {
            var date = DateTime.Today.AddDays(20);
            if (startDate > date)
                throw new ValidationException("You can not add an employee in the future.");
        }
    }
}
