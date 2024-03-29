﻿using licenta.Models.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface IEmployeeService
    {
        public Task<int> CreateEmployee(EmployeeSave employeeSave, string password);

        public Task<List<EmployeeGet>> GetEmployees();

        public Task<EmployeeGet> GetEmployeeById(int id);

        public Task UpdateEmployee(EmployeeUpdate employeeUpdate, int id);

        public Task DeleteEmployeeById(int id);

        public Task<string> Login(string username, string password);

        public Task editPassword(int id, string oldPassword, string newPassword);
    }
}
