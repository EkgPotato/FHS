using FHS.Api.Controllers.Base;
using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using FHS.Interfaces.Api.Controllers.Base;
using FHS.Interfaces.Common.Crud;
using FHS.Interfaces.Services.Base;
using FHS.Utilities.Common.Crud;
using FHS.Utilities.Exceptions.Service;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FHS.Tests.Api.Controllers.Base
{
    public abstract class BaseControllerUnitTests<TListModel, TModel, TEntity, TBaseController, TService>
        where TBaseController : class, IBaseController<TListModel, TModel>
        where TEntity : class, IBaseEntity
        where TModel : class, IBaseModel, new()
        where TListModel : class, IBaseListModel
        where TService : class, IBaseCrudService<TListModel, TModel, TEntity>
    {
        protected readonly Mock<ILogger<TBaseController>> _loggerMock;
        protected readonly Mock<TService> _serviceMock;
        protected TBaseController? _controller;
        protected BaseControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<TBaseController>>();
            _serviceMock = new Mock<TService>();
        }

        [Fact]
        public async Task GetAsync_WithValidId_ReturnsOkResult()
        {
            //Arrange
            //var crudResult = new CrudResult();
            var item = new TModel();
            _serviceMock.Setup(s => s.GetAsync(It.IsAny<int>())).ReturnsAsync(item).Verifiable();

            // Act
            var result = await _controller.GetAsync(1);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeEquivalentTo(item);
        }

        [Fact]
        public async Task GetAsync_WithInvalidId_ReturnsBadRequest()
        {
            //Arrange 
            _serviceMock.Setup(s => s.GetAsync(It.IsAny<int>())).ThrowsAsync(new InvalidIdException()).Verifiable();

            //Act
            var result = await _controller.GetAsync(It.IsAny<int>());

            //Assert
            result.Result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task GetAsync_ExceptionThrown_ReturnsInternalServerErrorResult()
        {
            // Arrange
            int validId = 1;

            _serviceMock.Setup(x => x.GetAsync(validId))
                        .ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAsync(validId);

            // Assert
            result.Result.Should().BeOfType<ObjectResult>()
                .Which.StatusCode.Should().Be(500);
        }

        [Fact]
        public async Task GetListAsync_ServiceReturnsItems_ReturnsOk()
        {
            //Arrange
            var itemsList = new List<TListModel>();
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(itemsList).Verifiable();

            // Act
            var result = await _controller.GetListAsync();

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeEquivalentTo(itemsList);
        }

        [Fact]
        public async Task GetListAsync_ServiceReturnsNull_ReturnsBadRequest()
        {
            //Arrange
            List<TListModel> itemsList = null;
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(itemsList).Verifiable();

            //Act
            var result = await _controller.GetListAsync();

            //Assert
            result.Result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task GetListAsync_ExceptionThrown_ReturnInternalServerErrorResult()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllAsync())
                        .ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetListAsync();

            // Assert
            result.Result.Should().BeOfType<ObjectResult>()
                .Which.StatusCode.Should().Be(500);
        }

        [Fact]
        public async Task CreateAsync_WithValidEntity_ReturnsCreatedAtAction()
        {
            //Arrange
            var model = new TModel();
            _serviceMock.Setup(s => s.CreateAsync(model, It.IsAny<CrudResult>())).Verifiable();

            //Act
            var result = await _controller.CreateAsync(model);

            //Assert 
            var actionResult = result.Should().BeOfType<CreatedAtActionResult>().Which;
            actionResult.StatusCode.Should().Be(201);
            actionResult.RouteValues.Should().NotBeNull();
            actionResult.RouteValues["id"].Should().Be(model.Id);
            actionResult.Value.Should().BeEquivalentTo(model);
        }

        [Fact]
        public async Task CreateAsync_WithNullEntity_ReturnsBadRequestResult()
        {
            //Arrange
            _serviceMock.Setup(s => s.CreateAsync(null, It.IsAny<CrudResult>()))
                .ThrowsAsync(new ModelNullException())
                .Verifiable();

            // Act
            var result = await _controller.CreateAsync(null);

            //Assert 
            var actionResult = result.Should().BeOfType<BadRequestResult>().Which;
            actionResult.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task CreateAsync_WithInvalidEntity_ReturnsUnprocessableEntity()
        {
            // Arrange
            var model = new TModel();
            _serviceMock.Setup(s => s.CreateAsync(model, It.IsAny<CrudResult>()))
                .Callback((TModel model, ICrudResult result) => result.AddMessage("Test error message"))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateAsync(model);
            _serviceMock.Verify();

            //Assert 
            var actionResult = result.Should().BeOfType<UnprocessableEntityObjectResult>().Which;
            actionResult.StatusCode.Should().Be(422);

        }

        [Fact]
        public async Task CreateAsync_ExceptionThrown_ReturnInternalServerErrorResult()
        {
            // Arrange
            var model = new TModel();
            _serviceMock.Setup(s => s.CreateAsync(model, It.IsAny<CrudResult>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _controller.CreateAsync(model);
            _serviceMock.Verify();

            //Assert 
            result.Should().BeOfType<ObjectResult>()
                .Which.StatusCode.Should().Be(500);

        }

        [Fact]
        public async Task UpdateAsync_WithValidEntity_ReturnsCreatedAtAction()
        {
            //Arrange
            var model = new TModel();
            _serviceMock.Setup(s => s.UpdateAsync(It.IsAny<int>(), model, It.IsAny<CrudResult>())).Verifiable();

            //Act
            var result = await _controller.UpdateAsync(1, model);

            //Assert 
            var actionResult = result.Should().BeOfType<CreatedAtActionResult>().Which;
            actionResult.StatusCode.Should().Be(201);
            actionResult.Value.Should().Be(model);
        }

        [Fact]
        public async Task UpdateAsync_WithNullEntity_ReturnsBadRequestResult()
        {
            //Arrange
            _serviceMock.Setup(s => s.UpdateAsync(It.IsAny<int>(), null, It.IsAny<CrudResult>()))
                .ThrowsAsync(new ModelNullException())
                .Verifiable();

            // Act
            var result = await _controller.UpdateAsync(It.IsAny<int>(), null);

            //Assert 
            var actionResult = result.Should().BeOfType<BadRequestResult>().Which;
            actionResult.StatusCode.Should().Be(400);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task UpdateAsync_WithInvalidId_ReturnsBadRequestResult(int id)
        {
            //Arrange
            _serviceMock.Setup(s => s.UpdateAsync(id, It.IsAny<TModel>(), It.IsAny<CrudResult>()))
                .ThrowsAsync(new InvalidIdException())
                .Verifiable();

            // Act
            var result = await _controller.UpdateAsync(id, It.IsAny<TModel>());

            //Assert 
            var actionResult = result.Should().BeOfType<BadRequestResult>().Which;
            actionResult.StatusCode.Should().Be(400);

        }

        [Fact]
        public async Task UpdateAsync_WithInvalidEntity_ReturnsUnprocessableEntity()
        {
            // Arrange
            var model = new TModel();
            _serviceMock.Setup(s => s.UpdateAsync(It.IsAny<int>(), model, It.IsAny<CrudResult>()))
                .Callback((int id, TModel model, ICrudResult result) => result.AddMessage("Test error message"))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateAsync(1, model);

            //Assert 
            var actionResult = result.Should().BeOfType<UnprocessableEntityObjectResult>().Which;
            actionResult.StatusCode.Should().Be(422);

        }

        [Fact]
        public async Task UpdateAsync_ExceptionThrown_ReturnInternalServerErrorResult()
        {
            // Arrange
            var model = new TModel();
            _serviceMock.Setup(s => s.UpdateAsync(It.IsAny<int>(), model, It.IsAny<CrudResult>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _controller.UpdateAsync(1, model);
            _serviceMock.Verify();

            //Assert 
            result.Should().BeOfType<ObjectResult>()
                .Which.StatusCode.Should().Be(500);
        }

        [Fact]
        public async Task DeleteAsync_WithValidId_ReturnsOk()
        {
            //Arrange
            _serviceMock.Setup(i => i.DeleteAsync(It.IsAny<int>())).Verifiable();

            //Act
            var result = await _controller.DeleteAsync(1);

            //Assert
            result.Should().BeOfType<OkResult>()
                .Which.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task DeleteAsync_WithInvalidId_ReturnsBadRequest()
        {
            //Arrange
            _serviceMock.Setup(i => i.DeleteAsync(It.IsAny<int>()))
                .ThrowsAsync(new InvalidIdException());

            //Act
            var result = await _controller.DeleteAsync(-1);

            //Assert
            var actionResult = result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task DeleteAsync_ExceptionThrown_ReturnInternalServerErrorResult()
        {
            // Arrange
            var model = new TModel();
            _serviceMock.Setup(s => s.DeleteAsync(It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _controller.DeleteAsync(1);
            _serviceMock.Verify();

            //Assert 
            result.Should().BeOfType<ObjectResult>()
                .Which.StatusCode.Should().Be(500);
        }
    }
}
