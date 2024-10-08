using Microsoft.AspNetCore.Mvc;
using Proje.EntityFramework.Data;
using Proje.EntityFramework.Models;
using Proje.EntityFramework.Models.Requests;
using Proje.EntityFramework.Models.Responses;
using Proje.Services.Repositories;
using System.Text.RegularExpressions;

namespace Proje.Host.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        private readonly IGroupRepository _groupRepo;
        public GroupController(IGroupRepository entity)
        {
            _groupRepo = entity;
        }
        [HttpPost("AddGroup")]
        public async Task<ActionResult<GroupResponse>> AddGroup(GroupRequest request)
        {
            var item = await _groupRepo.Add(request);
            if (item != null) return item;
            return BadRequest();
        }
        [HttpGet("GetGroups")]
        public async Task<ActionResult<List<GroupResponse>>> GetAllGroups()
        {
            return Ok(await _groupRepo.GetAll());
        }
        [HttpGet("GetGroupById")]
        public async Task<ActionResult<GroupResponse>> GetById(int id)
        {
            return Ok(await _groupRepo.GetById(id));
        }
        [HttpPost("UpdateGroup")]
        public async Task<ActionResult<GroupResponse>> UpdateGroup(GroupRequest request, int id )
        {
            return Ok(await _groupRepo.UpdateById(request,id));
        }
        [HttpDelete("DeleteGroup")]
        public async Task<ActionResult<GroupResponse>> DeleteGroup(int id)
        {
            return Ok(await _groupRepo.Delete(id));
        }
    }
}
