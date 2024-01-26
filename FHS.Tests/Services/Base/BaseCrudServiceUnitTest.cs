using DataService.Data;
using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using FHS.Interfaces.Common.Crud;
using FHS.Interfaces.Mapper.Base;
using FHS.Interfaces.Services.Base;
using FHS.Resources.Messages;
using FHS.Tests.TestHelpers;
using FHS.Utilities.Exceptions.Service;
using FluentAssertions;
using Moq;
using Serilog;
using Xunit;

namespace FHS.Tests.Services.Base
{
    public abstract class BaseCrudServiceUnitTest<TListModel, TModel, TEntity, TMapper, TService> : IClassFixture<DatabaseFixture<TEntity>>
        where TListModel : class, IBaseListModel, new()
        where TModel : class, IBaseModel, new()
        where TEntity : class, IBaseEntity, new()
        where TMapper : class, IBaseMapper<TListModel, TModel, TEntity>
        where TService : class, IBaseCrudService<TListModel, TModel, TEntity>
    {
        protected readonly Mock<ILogger> _loggerMock;
        protected readonly AppDbContext _dbContext;
        protected readonly Mock<TMapper> _mapperMock;
        protected readonly DatabaseFixture<TEntity> _fixture;
        protected TService _service;

        protected BaseCrudServiceUnitTest(DatabaseFixture<TEntity> fixture)
        {
            _loggerMock = new Mock<ILogger>();
            _mapperMock = new Mock<TMapper>();

            _fixture = fixture;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public async Task GetAsync_ValidId_ReturnsModel()
        {
            // Arrange
            var mappedEntity = new TModel { Id = 1 };
            var result = new Mock<ICrudResult>();
            _mapperMock.Setup(i => i.MapToModel(It.IsAny<TEntity>())).Returns(mappedEntity);

            // Act
            var model = await _service.GetAsync(1, result.Object);

            // Assert
            model.Should().NotBeNull();
            model.Should().BeEquivalentTo(mappedEntity);
            result.Verify(r => r.AddMessage(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task GetAllAsync_InValidId_ReturnsNull()
        {
            //Arrange
            var result = new Mock<ICrudResult>();

            // Act
            var model = await _service.GetAsync(-1, result.Object);

            // Assert
            model.Should().BeNull();
            result.Verify(r => r.AddMessage(CrudResultMessages.GetAsync_InvalidId), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsListModels()
        {
            //Arrange
            var mappedEntities = new List<TListModel>()
            {
                new TListModel() { Id = 1 },
                new TListModel() { Id = 2 },
                new TListModel() { Id = 3 },
            };
            _mapperMock.Setup(i => i.MapToListModels(It.IsAny<IEnumerable<TEntity>>())).Returns(mappedEntities);

            // Act
            var result = new Mock<ICrudResult>();
            var list = await _service.GetAllAsync(result.Object);

            // Assert
            list.Should().NotBeNull();
            list.Should().HaveCount(3);
            list.Should().BeEquivalentTo(mappedEntities);
        }

        [Fact]
        public async Task CreateAsync_WithValidModel_CreatesEntity()
        {
            //Arrange 
            var model = new TModel();
            var entity = new TEntity();
            _mapperMock.Setup(i => i.MapToEntity(model)).Returns(entity);
            var entitiesBefore = _dbContext.Set<TEntity>().ToList();

            //Act
            var result = new Mock<ICrudResult>();
            await _service.CreateAsync(model, result.Object);
            var entitiesAfter = _dbContext.Set<TEntity>().ToList();

            //Assert
            result.Verify(r => r.AddMessage(It.IsAny<string>()), Times.Never);
            _dbContext.Set<TEntity>().Should().Contain(e => e.Id == model.Id);
            entitiesAfter.Should().HaveCount(entitiesBefore.Count + 1);
            entitiesBefore.Last().Should().BeEquivalentTo(entity);

            //Clean
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task CreateAsync_WithNull_ThrowsError()
        {
            //Arrange
            var entitiesBefore = _dbContext.Set<TEntity>().ToList();

            //Act
            await _service.Invoking(async x => await x.CreateAsync(null, new Mock<ICrudResult>().Object))
                .Should().ThrowAsync<ModelNullException>();

            var entitiesAfter = _dbContext.Set<TEntity>().ToList();

            //Assert
            entitiesAfter.Should().BeEquivalentTo(entitiesBefore);
        }

        [Fact]
        public async Task UpdateAsync_WithValidModel_UpdatesEntity()
        {
            ////Seed
            //var entity = new TEntity();
            //_dbContext.Set<TEntity>().Add(entity);
            //_dbContext.SaveChanges();

            ////Arrange 
            //entity = _dbContext.Set<TEntity>().FirstOrDefault(i => i.Id == entity.Id);
            //var updatedModel = _mapperMock.Object.MapToModel(entity);
            //updatedModel.

            ////Act
            //var result = new Mock<ICrudResult>();
            //await _service.UpdateAsync(entity.Id, model, result.Object);

            ////Assert
            //result.Verify(r => r.AddMessage(It.IsAny<string>()), Times.Never);
            //_dbContext.Set<TEntity>().Last().Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async Task UpdateAsync_WithNull_ThrowsError()
        {
            //Arrange
            var entitiesBefore = _dbContext.Set<TEntity>().ToList();

            //Act
            await _service.Invoking(async x => await x.UpdateAsync(1, null, new Mock<ICrudResult>().Object))
                .Should().ThrowAsync<ModelNullException>();

            var entitiesAfter = _dbContext.Set<TEntity>().ToList();

            //Assert
            entitiesAfter.Should().BeEquivalentTo(entitiesBefore);
        }

        [Fact]
        public async Task UpdateAsync_WithInvalidId_ThrowsError()
        {
            //Act
            await _service.Invoking(async x => await x.UpdateAsync(-1, new TModel(), new Mock<ICrudResult>().Object))
                .Should().ThrowAsync<InvalidIdException>();
        }
    }
}
