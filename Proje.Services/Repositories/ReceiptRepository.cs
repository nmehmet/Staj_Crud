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
    public class ReceiptRepository : BaseRepository<ReceiptRequest, ReceiptResponse ,Receipt>, IReceiptRepository
    {
        private readonly IProductRepoSitory _productRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ReceiptRepository(DataContext context, IProductRepoSitory productRepoSitory ,ICustomerRepository customerRepository, IMapper mapper) : base(context,mapper)
        {
            _productRepo = productRepoSitory;
            _customerRepo = customerRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ReceiptResponse> Buy(ReceipBuyRequest request)
        {
            //TODO Sadeleştir
            var soldRequest = _mapper.Map<ProductSoldRequest>(request);
            Customer custom = _mapper.Map<Customer>(await _customerRepo.GetById(request.BuyerId));
            if (custom != null) 
            {
                ProductSoldResponse res = await _productRepo.Sold(soldRequest);                            
                Receipt receipt = new Receipt();
                receipt.Quanity = request.Quanity;
                receipt.BuyerId = request.BuyerId;
                receipt.Name = _mapper.Map<Product>(await _productRepo.GetById(request.BuyingProductid)).Name;
                await Add(_mapper.Map<ReceiptRequest>(receipt));
                return _mapper.Map<ReceiptResponse>(receipt);
            }
            throw new Exception("Aranan müşteri bulunamadı...");
        }
        public async Task<List<ReceiptView>> GetAllByView()
        {
            return await _context.Receipt_View.ToListAsync();
        }
   
    }
}
