using licenta.Interfaces.Services;
using licenta.Models.Repairs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace licenta.Services
{
    public class RepairsService : IRepairsService
    {
        public Task<int> CreateRepairs(RepairsSave repairsSave)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRepairById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RepairsGet>> GetRepairs()
        {
            throw new NotImplementedException();
        }

        public Task<List<RepairsGet>> GetRepairsByEmployeeId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RepairsGet> GetRepairsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRepair(RepairsUpdate repairsUpdate, int id)
        {
            throw new NotImplementedException();
        }
    }
}
