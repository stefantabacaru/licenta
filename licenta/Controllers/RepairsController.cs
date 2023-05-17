using AutoMapper;
using licenta.DtoModels.Repairs;
using licenta.Interfaces.Services;
using licenta.Models.Repairs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace licenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairsController : ControllerBase
    {
        private readonly IRepairsService repairsService;
        private readonly IMapper mapper;

        public RepairsController(IRepairsService repairsService, IMapper mapper)
        {
            this.repairsService = repairsService ?? throw new ArgumentNullException(nameof(repairsService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("getByEmployeeId/{id}")]
        public async Task<IActionResult> GetRepairsByEmployeeId(int employeeId)
        {
            return Ok(await repairsService.GetRepairsByEmployeeId(employeeId).ConfigureAwait(false));
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetRepairs()
        {
            return Ok(await repairsService.GetRepairs().ConfigureAwait(false));
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetRepairById(int id)
        {
            var repair = await repairsService.GetRepairsById(id).ConfigureAwait(false);
            if (repair != null)
            {
                return Ok(repair);
            }

            return NotFound($"cant find repair with the id: {id}");
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> CreateRepair(RepairsSaveDto repairDto)
        {
            var repair = mapper.Map<RepairsSave>(repairDto);
            var repairId = await repairsService.CreateRepairs(repair).ConfigureAwait(false);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + repairId,
                repair);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteRepairById(int id)
        {
            await repairsService.DeleteRepairById(id).ConfigureAwait(false);
            return Ok();
        }

        [HttpPatch]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditRepair(int id, RepairsUpdateDto repairDto)
        {
            var repair = mapper.Map<RepairsUpdate>(repairDto);
            await repairsService.UpdateRepair(repair, id).ConfigureAwait(false);
            return Ok();
        }
    }
}
