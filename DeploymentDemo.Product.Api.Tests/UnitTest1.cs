using DeploymentDemo.DTOs;
using System.ComponentModel.DataAnnotations;

namespace DeploymentDemo.Product.Api.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateProductRequest_InvalidData_ShouldFailValidation()
        {
            //arrange
            var request = new CreateProductRequestDto
            {
                Name = "",
                Price = -500
            };
            var context = new ValidationContext(request);
            var results = new List<ValidationResult>();

            //act
            var isValid = Validator.TryValidateObject(
                request, context, results, true);

            //assert
            Assert.False(isValid);
            Assert.NotEmpty(results);
        }
        [Fact]
        public void CreateProductRequest_ValidData_ShouldPassValidation()
        {
            // Arrange
            var request = new CreateProductRequestDto
            {
                Name = "Laptop",
                Price = 75000
            };

            var context = new ValidationContext(request);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(
                request,
                context,
                results,
                validateAllProperties: true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(results);
        }
    }
}