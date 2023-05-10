using licenta.Models.Repairs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface IRepairsService
    {
        public Task CreateRepairs(RepairsSave repairsSave);

        public Task<List<RepairsGet>> GetRepairs();

        public Task<RepairsGet> GetRepairsById(int id);

        public Task UpdateRepair(RepairsUpdate repairsUpdate);

        public Task DeleteRepairById(int id);
    }
}
