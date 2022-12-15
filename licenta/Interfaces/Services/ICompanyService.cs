using licenta.Models.Company;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface ICompanyService
    {
        public Task<int> CreateCompany();

        public Task<CompanyGet> GetCompany();
    }
}
