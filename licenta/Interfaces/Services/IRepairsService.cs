using licenta.Models.Repairs;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface IRepairsService
    {
        public Task<int> CreateRepairs(RepairsSave repairsSave);

        public Task<RepairsSave> GetRepairs();
    }
}
