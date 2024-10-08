using Microsoft.AspNetCore.Mvc;
using Proje.EntityFramework.Models;
using Proje.EntityFramework.Models.Requests;
using Proje.EntityFramework.Models.Responses;
using Proje.Services.Repositories;



namespace Proje.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : Controller
    {
        private readonly IReceiptRepository _receiptRepo;

        public ReceiptController( IReceiptRepository receiptRepository)
        {
            _receiptRepo =receiptRepository;
        }
        [HttpGet("GetReceipts")]
        public async Task<ActionResult<List<ReceiptResponse>>> GetAllReceipt()
        {
            var customer = await _receiptRepo.GetAll();
            return Ok(customer);
        }
        [HttpPut("Buying")]
        public async Task<ActionResult<ReceiptBuyResponse>> BuyItem(ReceipBuyRequest request)
        {
            var response = await _receiptRepo.Buy(request);
            if (response != null) return Ok(response);
            return BadRequest();
        }
        [HttpGet("GetReceiptById")]
        public async Task<ActionResult<ReceiptResponse>> GetReceiptById(int id)
        {
            return Ok(await _receiptRepo.GetById(id));
        }
        [HttpPost("UpdateReceipt")]
        public async Task<ActionResult<ReceiptResponse>> UpdateCustomer(ReceiptRequest request, int id)
        {
            return Ok(await _receiptRepo.UpdateById(request, id));
        }
        [HttpDelete("DeleteReceipt")]
        public async Task<ActionResult<ReceiptResponse>> DeleteReceipt(int id)
        {
            return Ok(await _receiptRepo.Delete(id));
        }
        [HttpGet("GetView")]
        public async Task<ActionResult<List<ReceiptView>>> GetAllByView()
        {
            return await _receiptRepo.GetAllByView();
        }
    }
}
