using licenta.Context;
using licenta.DAOModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using licenta.DtoModels.Employee;
using Microsoft.Extensions.Configuration;

namespace licenta.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static EmployeeDao employee= new EmployeeDao();
        private readonly ContextDB _context;
        private IConfiguration _configuration;

        public AuthController(IConfiguration configuration, ContextDB context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(_context.Employees.ToList());
        }

        [HttpGet]
        [Route("userIdNotAdminYet/{id}")]
        public async Task<IActionResult> userIdNotAdminYet(int id)
        {
            var existingUser = _context.Employees.SingleOrDefault(x => x.EmployeeId == id);
            if (existingUser.Role == "Admin")
                return Ok(false);
            return Ok(true);
        }

        [HttpPatch, Authorize(Roles = "User,Admin")]
        [Route("edit/{newPassword}")]
        public async Task<IActionResult> editPassword(EmployeeDao request, string newPassword)
        {
            try
            {
                var existingUser = _context.Employees.SingleOrDefault(x => x.Username == request.Username);
                if (existingUser != null)
                {
                    if (!VerifyPasswordHask(request.PasswordHash, existingUser.PasswordHash, existingUser.PasswordSalt))
                    {
                        return BadRequest("Wrong password");
                    }
                    CreatePassworHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);
                    existingUser.PasswordHash = passwordHash;
                    existingUser.PasswordSalt = passwordSalt;
                    _context.Employees.Update(existingUser);
                    _context.SaveChanges();

                    return Ok(existingUser);
                }
                return BadRequest("User not found");
            }
            catch (Exception e)
            {
                return BadRequest("User not found");
            }
        }


        [HttpPatch, Authorize(Roles = "Admin")]
        [Route("setAsAdmin/{id}")]
        public async Task<IActionResult> setAsAdmin(int id)
        {
            try
            {
                var existingUser = _context.Employees.SingleOrDefault(x => x.EmployeeId == id);
                if (existingUser != null)
                {
                    existingUser.Role = "Admin";
                    _context.Employees.Update(existingUser);
                    _context.SaveChanges();

                    return Ok(existingUser);
                }
                return BadRequest("User not found");
            }
            catch (Exception e)
            {
                return BadRequest("User not found");
            }
        }

        [HttpPatch, Authorize(Roles = "Admin")]
        [Route("setAsUser/{id}")]
        public async Task<IActionResult> setAsUser(int id)
        {
            try
            {
                var existingUser = _context.Employees.SingleOrDefault(x => x.EmployeeId == id);
                if (existingUser != null)
                {
                    existingUser.Role = "User";
                    _context.Employees.Update(existingUser);
                    _context.SaveChanges();

                    return Ok(existingUser);
                }
                return BadRequest("User not found");
            }
            catch (Exception e)
            {
                return BadRequest("User not found");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<EmployeeDao>> Register(EmployeeDao request)
        {

            var existingUser = _context.Employees.SingleOrDefault(x => x.Username == request.Username);
            if (existingUser != null)
                return BadRequest("Username is already taken");

            var user = new EmployeeDao();
            CreatePassworHash(request.PasswordHash, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Username = request.Username;
            user.Role = request.Role;

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Ok(user);
        }

        private void CreatePassworHash(byte[] passwordHash1, out byte[] passwordHash2, out byte[] passwordSalt)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("getRole/{Username}")]
        public async Task<IActionResult> GetEmployees(string Username)
        {
            var user = _context.Employees.SingleOrDefault(x => x.Username == Username);
            return Ok(user.Role);
        }


        [HttpDelete, Authorize(Roles = "Admin")]
        [Route("delete")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var user = _context.Employees.SingleOrDefault(x => x.EmployeeId == Id);
            _context.Employees.Remove(user);
            _context.SaveChanges();
            return Ok();
        }



        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(EmployeeGetDto request)
        {
            var user = new EmployeeDao();
            try
            {
                user = _context.Employees.SingleOrDefault(x => x.Username == request.Username);
            }
            catch (Exception e)
            {
                return BadRequest("User not found");
            }

            if (user == null)
            {
                return BadRequest("User not found");

            }

            if (!VerifyPasswordHask(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }

            string token = CreateToken(employee);

            return Ok(token);
        }

        private bool VerifyPasswordHask(object password, byte[] passwordHash, byte[] passwordSalt)
        {
            throw new NotImplementedException();
        }

        private string CreateToken(EmployeeDao employee)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, employee.Username),
                new Claim(ClaimTypes.Role, employee.Role)
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