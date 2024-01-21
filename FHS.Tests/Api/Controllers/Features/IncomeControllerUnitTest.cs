using FHS.Api.Controllers.Features;
using FHS.Domain.Interfaces.Model.Features;
using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Services.Features;
using FHS.Tests.Api.Controllers.Base;
using FHS.Utilities.Common.Crud;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FHS.Tests.Api.Controllers.Features
{
    public class IncomeControllerUnitTest : BaseControllerUnitTests<IncomeListModel, IncomeModel, Income, IncomeController, IIncomeService>
    {
        public IncomeControllerUnitTest() : base()
        {
            _controller = new IncomeController(_loggerMock.Object, _serviceMock.Object);
        }


        //[Fact]
        //public async Task GetAsync_WithValidId_ReturnsOkResult()
        //{
        //    //Arrange
        //    //var crudResult = new CrudResult();
        //    var item = new IncomeModel();
        //    _incomeServiceMock.Setup(s => s.GetAsync(It.IsAny<int>(), It.IsAny<CrudResult>())).ReturnsAsync(item).Verifiable();

        //    // Act
        //    var result = await _incomeController.GetAsync(1);

        //    // Assert
        //    result.Result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeEquivalentTo(item);
        //}

        //[Fact]
        //public async Task GetAsync_WithInvalidId_ReturnsBadRequest()
        //{
        //    //Arrange 
        //    var id = -1;

        //    //Act
        //    var result = await _incomeController.GetAsync(id);

        //    //Assert
        //    result.Result.Should().BeOfType<BadRequestObjectResult>();
        //}

        //[Fact]
        //public async Task GetAsync_ExceptionThrown_ReturnsInternalServerErrorResult()
        //{
        //    // Arrange
        //    int validId = 1;

        //    _incomeServiceMock.Setup(x => x.GetAsync(validId, It.IsAny<CrudResult>()))
        //                .ThrowsAsync(new Exception());

        //    // Act
        //    var result = await _incomeController.GetAsync(validId);

        //    // Assert
        //    result.Result.Should().BeOfType<ObjectResult>()
        //        .Which.StatusCode.Should().Be(500);
        //}
    }
}
