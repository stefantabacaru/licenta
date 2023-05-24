using AutoMapper;
using licenta.DAOModels;
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
        private Context.ContextDB _context;
        private readonly IMapper mapper;

        public CompanyService(Context.ContextDB context, IMapper mapper)
        {
            _context = context;

            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> CreateCompany(CompanyGet company)
        {
            var companySaveDao = mapper.Map<CompanyDao>(company);
            _context.Company.Add(companySaveDao);
            _context.SaveChanges();
            return companySaveDao.CompanyId;
        }

        public async Task<CompanyGet> GetCompany()
        {
            return mapper.Map<CompanyGet>(_context.Company.FirstOrDefault());
        }
    }
}
