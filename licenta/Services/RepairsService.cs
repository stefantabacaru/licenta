using AutoMapper;
using licenta.DAOModels;
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
        private Context.ContextDB _context;
        private readonly IMapper mapper;

        public RepairsService(Context.ContextDB context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> CreateRepairs(RepairsSave repairsSave)
        {
            var repairSaveDao = mapper.Map<RepairsDao>(repairsSave);
            _context.Repairs.Add(repairSaveDao);
            _context.SaveChanges();
            return repairSaveDao.RepairId;
        }

        public async Task DeleteRepairById(int id)
        {
            var repair = _context.Repairs.SingleOrDefault(x => x.RepairId == id);
            _context.Repairs.Remove(repair);
            _context.SaveChanges();
        }

        public async Task<List<RepairsGet>> GetRepairs()
        {
            return mapper.Map<List<RepairsGet>>(_context.Repairs.ToList());
        }

        public async Task<List<RepairsGet>> GetRepairsByEmployeeId(int id)
        {
            return mapper.Map<List<RepairsGet>>(_context.Repairs.Where(x => x.EmployeeResponsibleId == id).ToList());
        }

        public async Task<RepairsGet> GetRepairsById(int id)
        {
            return mapper.Map<RepairsGet>(_context.Repairs.SingleOrDefault(x => x.RepairId == id));
        }

        public async Task UpdateRepair(RepairsUpdate repairsUpdate, int id)
        {
            var repair = _context.Repairs.SingleOrDefault(x => x.RepairId == id);
            if (repairsUpdate != null)
            {
                repair.Problem = repairsUpdate.Problem;
                repair.RepairCost = repairsUpdate.RepairCost;
                repair.RepairDuration = repairsUpdate.RepairDuration;

                _context.Repairs.Update(repair);
                _context.SaveChanges();
            }
        }
    }
}
