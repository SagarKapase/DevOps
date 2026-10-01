using DeploymentDemo.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DeploymentDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeploymentController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<DeploymentController> _logger;
        public DeploymentController(IHttpClientFactory httpClientFactory, IWebHostEnvironment environment, ILogger<DeploymentController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _environment = environment;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Deployment API endpoint was called.");
            return Ok(new
            {
                application = "DeploymentDemo.Api",
                version = "1.0",
                message = "API is running"
            });
        }
        [HttpGet("product")]
        public async Task<IActionResult> GetProduct()
        {
            var client = _httpClientFactory.CreateClient("ProductService");

            var response = await client.GetAsync("/api/product");
            _logger.LogInformation("Calling Product Service at {BaseAddress}",client.BaseAddress);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            var productResponse = await response.Content.ReadFromJsonAsync<ProductResponseDto>();

            return Ok(new
            {
                callingService = "DeploymentDemo.Api",
                productServiceResponse = productResponse
            });
        }
        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(new
            {
                application = "DeploymentDemo.Api",
                status = "Running",
                //environment = "Development",
                environment = _environment.EnvironmentName,
                version = "1.0"
            });
        }
    }
}
