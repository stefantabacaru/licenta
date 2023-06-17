using licenta.Interfaces.Services;
using licenta.Models.Employee;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using licenta.DAOModels;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace licenta.Services
{
    public class EmployeeService : IEmployeeService

    {
        private Context.ContextDB _context;
        private readonly IMapper mapper;
        private IConfiguration _configuration;

        public EmployeeService(Context.ContextDB context, IMapper mapper, IConfiguration configuration)
        {   _configuration = configuration;
            _context = context;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> CreateEmployee(EmployeeSave employeeSave, string password)
        {
            ValidateStartDate(employeeSave.StartDate);

            var existingUser = _context.Employees.SingleOrDefault(x => x.Username == employeeSave.Username);
            if (existingUser != null)
                throw new Exception("Username is already taken");

            CreatePassworHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            employeeSave.PasswordHash = passwordHash;
            employeeSave.PasswordSalt = passwordSalt;
            
            var employeeSaveDao = mapper.Map<EmployeeDao>(employeeSave);

            employeeSaveDao.CompanyId = 1;
            _context.Employees.Add(employeeSaveDao);
            _context.SaveChanges();
            return employeeSaveDao.EmployeeId;
        }

        public async Task DeleteEmployeeById(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.EmployeeId == id);
            if (employee != null)
            {
                employee.EndDate = DateTime.Now;

                _context.Employees.Update(employee);
                _context.SaveChanges();
            }
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

        public async Task editPassword(int id, string oldPassword, string newPassword)
        {
                var existingUser = _context.Employees.SingleOrDefault(x => x.EmployeeId == id);
                if (existingUser != null)
                {
                    if (!VerifyPasswordHask(oldPassword, existingUser.PasswordHash, existingUser.PasswordSalt))
                    {
                        throw new Exception("Wrong password");
                    }
                    CreatePassworHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);
                    existingUser.PasswordHash = passwordHash;
                    existingUser.PasswordSalt = passwordSalt;
                    _context.Employees.Update(existingUser);
                    _context.SaveChanges();
                }
        }

        public async Task<string> Login(string username, string password)
        {
            var user = new EmployeeDao();
            try
            {
                user = _context.Employees.SingleOrDefault(x => x.Username == username);
            }
            catch (Exception e)
            {
                throw new Exception("User not found");
            }

            if (user == null)
            {
                throw new Exception("User not found");

            }

            if (!VerifyPasswordHask(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Wrong password");
            }

            return CreateToken(user);
        }

        private void ValidateStartDate(DateTime startDate)
        {
            var date = DateTime.Today.AddDays(20);
            if (startDate > date)
                throw new ValidationException("You can not add an employee in the future.");
        }

        private string CreateToken(EmployeeDao user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
               );

            var jtw = new JwtSecurityTokenHandler().WriteToken(token);
            return jtw;
        }
        private void CreatePassworHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHask(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
