using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Proje.EntityFramework.Models;
using Proje.EntityFramework.Data;
using Proje.EntityFramework.Models.Responses;
using Proje.EntityFramework.Models.Requests;
using AutoMapper;

namespace Proje.Services.Repositories
{
    public class ProductRepository : BaseRepository<ProductRequest,ProductResponse,Product>, IProductRepoSitory
    {
        private readonly ISubGroupRepository _subGroupRepo;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(DataContext context, IMapper mapper, ISubGroupRepository subGroupRepo) : base(context,mapper)
        {
            _mapper = mapper;
            _subGroupRepo = subGroupRepo;
            _context = context;
        }
        public async Task<ProductSoldResponse> Sold(ProductSoldRequest request)
        {
            ProductSoldResponse res = new ProductSoldResponse();
            Product item =_mapper.Map<Product>(await GetById(request.SoldProductId));
            if(item != null && item.Stock > request.Quanity)
            {
                item.Stock =item.Stock - request.Quanity;
                await UpdateById(_mapper.Map<ProductRequest>(item), item.Id);
                res.Result = true;
                return res;
            }
            throw new Exception("Yeterli Ürün yok vaya ürün bulunamadı...");
        }
        public async override Task<ProductResponse> Add(ProductRequest request)
        {
            var customer =await _subGroupRepo.GetById(request.SubGroupId);
            if (customer != null)
            {
                var item = _mapper.Map<Product>(request);
                await _context.AddAsync(item);
                await Save();
                return _mapper.Map<ProductResponse>(item);
            }
            throw new Exception("Aranılan SubGroup bulunamadı....");
        }
    }
}
