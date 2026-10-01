using DeploymentDemo.DTOs;
using DeploymentDemo.Product.Api.Data;
using DeploymentDemo.Product.Api.DTOs;
using DeploymentDemo.Product.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DeploymentDemo.Product.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var response = new ProductResponseDto
        //    {
        //        Service = "DeploymentDemo.Product.Api",
        //        Version = "1.0",
        //        Message = "Product service is running"
        //    };
        //    return Ok(response);
        //}
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequestDto request)
        {
            var Products = new Products
            {
                Name = request.Name,
                Price = request.Price
            };
            _context.Products.Add(Products);
            await _context.SaveChangesAsync();
            return Ok(Products);
        }
    }
}
