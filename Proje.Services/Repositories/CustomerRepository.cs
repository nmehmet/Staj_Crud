using AutoMapper;
using Proje.EntityFramework.Data;
using Proje.EntityFramework.Models;
using Proje.EntityFramework.Models.Requests;
using Proje.EntityFramework.Models.Responses;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Services.Repositories
{
    

    public class CustomerRepository: BaseRepository<CustomerRequest,CustomerResponse,Customer> , ICustomerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(DataContext context, IMapper mapper) : base(context, mapper) 
        {
            _context = context; 
            _mapper = mapper;
        }
    }
}
