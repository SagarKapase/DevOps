using System.ComponentModel.DataAnnotations;

namespace DeploymentDemo.DTOs
{
    public class CreateProductRequestDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
    }
}
