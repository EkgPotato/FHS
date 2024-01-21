using FHS.Api.Controllers.Features;
using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Api.Controllers.Base;
using FHS.Interfaces.Services.Base;
using FHS.Interfaces.Services.Features;
using FHS.Utilities.Common.Crud;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _serviceMock.Setup(s => s.GetAsync(It.IsAny<int>(), It.IsAny<CrudResult>())).ReturnsAsync(item).Verifiable();

            // Act
            var result = await _controller.GetAsync(1);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeEquivalentTo(item);
        }

        [Fact]
        public async Task GetAsync_WithInvalidId_ReturnsBadRequest()
        {
            //Arrange 
            var id = -1;

            //Act
            var result = await _controller.GetAsync(id);

            //Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task GetAsync_ExceptionThrown_ReturnsInternalServerErrorResult()
        {
            // Arrange
            int validId = 1;

            _serviceMock.Setup(x => x.GetAsync(validId, It.IsAny<CrudResult>()))
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
            _serviceMock.Setup(s => s.GetAllAsync(It.IsAny<CrudResult>())).ReturnsAsync(itemsList).Verifiable();

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
            _serviceMock.Setup(s => s.GetAllAsync(It.IsAny<CrudResult>())).ReturnsAsync(itemsList).Verifiable();

            //Act
            var result = await _controller.GetListAsync();

            //Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task GetListAsync_ExceptionThrown_ReturnInternalServerErrorResult()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllAsync(It.IsAny<CrudResult>()))
                        .ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetListAsync();

            // Assert
            result.Result.Should().BeOfType<ObjectResult>()
                .Which.StatusCode.Should().Be(500);
        }

    }
}
