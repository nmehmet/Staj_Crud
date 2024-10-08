using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Proje.EntityFramework.Models;
using Proje.EntityFramework.Data;
using Proje.EntityFramework.Models.Requests;
using Proje.EntityFramework.Models.Responses;
using AutoMapper;

namespace Proje.Services.Repositories
{
    public class SubGroupRepository : BaseRepository<SubGroupRequest, SubGroupResponse, SubGroup>, ISubGroupRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SubGroupRepository(DataContext context, IMapper mapper) : base(context,mapper)
        {
            _context = context;
            _mapper= mapper;
        }
    }
}
