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
using Microsoft.EntityFrameworkCore;
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
            _mapperMock.Setup(i => i.MapToModel(It.IsAny<TEntity>())).Returns(mappedEntity);

            // Act
            var model = await _service.GetAsync(1);

            // Assert
            model.Should().NotBeNull();
            model.Should().BeEquivalentTo(mappedEntity);
        }

        [Fact]
        public async Task GetAsync_WithInvalidId_ThrowsInvalidIdException()
        {
            await _service.Invoking(async x => await x.GetAsync(-1))
                .Should().ThrowAsync<InvalidIdException>();
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
            var list = await _service.GetAllAsync();

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
            entitiesAfter.Last().Should().BeEquivalentTo(entity);

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
            // Arrange
            var id = 1; 
            var testModel = new TModel();
            var testResult = new Mock<ICrudResult>();

            var existingEntity = await _dbContext.Set<TEntity>().FindAsync(id);
            _mapperMock.Setup(mapper => mapper.MapToEntity(It.IsAny<TModel>())).Returns(existingEntity);

            // Act
            await _service.UpdateAsync(id, testModel, testResult.Object);

            // Assert
            _dbContext.Entry(existingEntity).Reload();
            var updatedEntity = await _dbContext.Set<TEntity>().FindAsync(id);
            existingEntity.UpdatedDate.Should().Be(updatedEntity.UpdatedDate);
            existingEntity.UpdatedDate.Should().BeAfter(existingEntity.CreatedDate);

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

        [Fact]
        public async Task DeletASync_WithValidId_DeletesEntity()
        {
            // Arrange
            var entity = new TEntity(); 
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            // Detach the entity
            //The instance of entity type 'Income' cannot be tracked because another instance with the key value '{Id: 4}'
            //is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached.
            _dbContext.Entry(entity).State = EntityState.Detached; 

            int id = entity.Id;
            var entitiesBeforeCount = _dbContext.Set<TEntity>().Count();

            // Act
            await _service.DeleteAsync(id);
            var entitiesAfterCount = _dbContext.Set<TEntity>().Count();

            // Assert
            entitiesAfterCount.Should().Be(entitiesBeforeCount - 1);
        }

        [Fact]
        public async Task DeleteEntity_WhenEntityDoesNotExist_ShouldThrowInvalidIdException()
        {
            //Act & Assert
            await _service.Invoking(async x => await x.DeleteAsync(-1))
                .Should().ThrowAsync<InvalidIdException>();
        }
    }
}
