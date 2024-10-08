using Microsoft.AspNetCore.Mvc;
using Proje.EntityFramework.Data;
using Proje.EntityFramework.Models;
using Proje.EntityFramework.Models.Requests;
using Proje.EntityFramework.Models.Responses;
using Proje.Services.Repositories;

namespace Proje.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupGroupController : ControllerBase
    {
        private readonly ISubGroupRepository _subGroupRepo;

        public SupGroupController(DataContext context, ISubGroupRepository entity)
        {
            _subGroupRepo = entity;
        }

        [HttpGet("GetSubGroups")]
        public async Task<ActionResult<List<SubGroupResponse>>> GetAllSubGroups()
        {
            var subgroups = await _subGroupRepo.GetAll();
            return Ok(subgroups);
        }
        [HttpGet("GetSubGroupById")]
        public async Task<ActionResult<SubGroupResponse>> GetSubGroupById(int id)
        {
            return Ok(await _subGroupRepo.GetById(id));
        }
        [HttpPost("AddSubGroup")]
        public async Task<ActionResult<SubGroupResponse>> AddSubGroup(SubGroupRequest request)
        {
            var item = await _subGroupRepo.Add(request);
            if (item != null) return Ok(item);
            return BadRequest();
        }
        [HttpPost("UpdateSubGroup")]
        public async Task<ActionResult<SubGroupResponse>> UpdateSubGroup(SubGroupRequest request, int id)
        {
            return Ok(await _subGroupRepo.UpdateById(request, id));
        }
        [HttpDelete("DeleteSubGroup")]
        public async Task<ActionResult<SubGroupResponse>> DeleteSubGroup(int id)
        {
            return Ok(await _subGroupRepo.Delete(id));
        }

    }
}
