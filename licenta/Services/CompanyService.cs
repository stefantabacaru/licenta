using licenta.Interfaces.Services;
using licenta.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace licenta.Services
{
    public class CompanyService : ICompanyService
    {
        public Task<int> CreateCompany(CompanyGet company)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyGet> GetCompany()
        {
            throw new NotImplementedException();
        }
    }
}
