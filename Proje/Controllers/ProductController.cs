using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Proje.EntityFramework.Models;
using Proje.EntityFramework.Models.Requests;
using Proje.EntityFramework.Models.Responses;
using Proje.Services.Repositories;
using System.Runtime.CompilerServices;

namespace Proje.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepoSitory _productRepo;
        public ProductController(IProductRepoSitory productRepoSitory)
        {
            _productRepo = productRepoSitory;
        }
        [HttpPut("SoldItem")]
        public async Task<ActionResult<ProductSoldResponse>> SoldItem(ProductSoldRequest request)
        {
            var item = await _productRepo.Sold(request);
            if (item != null) return Ok(item);
            return BadRequest();          
        }
        [HttpGet("GetProductByID{id}")]
        public async Task<ActionResult<ProductResponse>> GetProductByID(int id)
        {
            var item = await _productRepo.GetById(id);
            if (item != null)return Ok(item);
            return BadRequest();
        }
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
        {
            var item = await _productRepo.GetAll();
            return Ok(item);
        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct(ProductRequest product)
        {
            var item = await _productRepo.Add(product);
            if (item != null) return Ok(item);
            return BadRequest();
        }
        [HttpPost("UpdateProduct")]
        public async Task<ActionResult<ProductResponse>> UpdateProduct(ProductRequest request, int id)
        {
            return Ok(await _productRepo.UpdateById(request, id));
        }
        [HttpDelete("DeeteProduct")]
        public async Task<ActionResult<ProductResponse>> DeleteProduct(int id)
        {
            return Ok(await _productRepo.Delete(id));
        }
    }
}
