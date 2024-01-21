using FHS.Api.Controllers.Features;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Common.Crud;
using FHS.Interfaces.Domain.Model.Features;
using FHS.Services.Interfaces.Features;
using FHS.Utilities.Common.Crud;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FHS.Tests.Api.Controllers.Features
{
    public class IncomeControllerUnitTest
    {
        private readonly Mock<IIncomeService> _incomeServiceMock;
        private readonly IncomeController _incomeControllerMock;
        public IncomeControllerUnitTest()
        {

            var loggerMock = new Mock<ILogger<IncomeController>>();
            _incomeServiceMock = new Mock<IIncomeService>();
            _incomeControllerMock = new IncomeController(loggerMock.Object, _incomeServiceMock.Object);
        }


        [Fact]
        public async Task GetAsync_WithValidId_ReturnsOkResult()
        {
            //Arrange
            var mockResult = new Mock<ICrudResult>();
            var mockItem = new Mock<IncomeModel>();
            _incomeServiceMock.Setup(s => s.GetAsync(1, mockResult.Object)).ReturnsAsync(mockItem.Object);

            // Act
            var result = await _incomeControllerMock.GetAsync(1);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }
    }
}
