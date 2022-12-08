using AutoMapper;
using AutoMapper.Execution;
using licenta.DAOModels;
using Microsoft.EntityFrameworkCore;
using steptrans.DtoModels.Employee;
using steptrans.Interfaces.Repositories;
using steptrans.Models.Employee;
using System;
using System.Threading.Tasks;

namespace steptrans.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private Context.ContextDB _context;
        private readonly IMapper mapper;



        public EmployeeRepository(Context.ContextDB context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<int> CreateEmployee(EmployeeSave employeeSave)
        {
            var employeeSaveDao = mapper.Map<EmployeeDao>(employeeSave);
            _context.Employees.Add(employeeSaveDao);
            _context.SaveChanges();
            return Task.FromResult(employeeSaveDao.EmployeeId);
        }
    }
}
