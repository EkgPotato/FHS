using DataService.Data;
using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using FHS.Interfaces.Common.Crud;
using FHS.Interfaces.Services.Base;
using FHS.Resources.Messages;
using FHS.Interfaces.Mapper.Base;
using Microsoft.EntityFrameworkCore;
using Serilog;
using FHS.Utilities.Exceptions.Service;

namespace FHS.Services.Service.Base;

public abstract class BaseCrudService<TListModel, TModel, TEntity, TMapper> : IBaseCrudService<TListModel, TModel, TEntity>
    where TListModel : class, IBaseListModel
    where TModel : class, IBaseModel
    where TEntity : class, IBaseEntity
    where TMapper : IBaseMapper<TListModel, TModel, TEntity>
{
    public readonly ILogger _logger;
    protected AppDbContext _dbContext;
    internal DbSet<TEntity> _dbSet;
    protected readonly TMapper _mapper;

    protected BaseCrudService(ILogger logger, AppDbContext dbContext, TMapper mapper)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TModel?> GetAsync(int id)
    {
        if (id <= 0)
        {
            throw new InvalidIdException();
        }

        var entity = await _dbSet.FirstOrDefaultAsync(i => i.Id == id);

        return _mapper.MapToModel(entity);
    }

    public async Task<IEnumerable<TListModel>> GetAllAsync()
    {
        var dbset = await _dbSet.ToListAsync();

        return _mapper.MapToListModels(dbset);
    }

    public async Task CreateAsync(TModel? model, ICrudResult result)
    {
        if (model == null)
        {
            throw new ModelNullException();
        }

        if (!Validate(model, result))
        {
            return;
        }

        using (var dbTransaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var entity = _mapper.MapToEntity(model);

                await BeforeCreateAsync(entity);
                entity.CreatedDate = DateTime.Now;
                entity.UpdatedDate = DateTime.Now;

                _dbSet.Add(entity);
                _dbContext.SaveChanges();

                dbTransaction.Commit();

                model.Id = entity.Id;
            }

            catch (Exception ex)
            {
                dbTransaction.Rollback();
                _logger.Error(LogMessage.Error_BaseCrudService_CreateAsync, ex);
                throw;
            }
        }
    }

    public async Task UpdateAsync(int id, TModel? model, ICrudResult result)
    {
        if (model == null)
        {
            throw new ModelNullException();
        }

        var existingEntity = await _dbSet.FirstOrDefaultAsync(i => i.Id == id);

        if (existingEntity == null)
        {
            throw new InvalidIdException();
        }

        if (!Validate(model, result))
        {
            return;
        }

        using (var dbTransaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var updatedEntity = _mapper.MapToEntity(model);

                await BeforeUpdateAsync(updatedEntity);

                updatedEntity.Id = id;
                updatedEntity.UpdatedDate = DateTime.Now;

                _dbSet.Attach(updatedEntity);
                _dbSet.Entry(updatedEntity).State = EntityState.Modified;
                _dbContext.SaveChanges();

                dbTransaction.Commit();

                model.Id = updatedEntity.Id;
            }

            catch (Exception ex)
            {
                dbTransaction.Rollback();
                _logger.Error(LogMessage.Error_BaseCrudService_UpdateAsync, ex);
                throw;
            }
        }
    }

    public virtual async Task BeforeCreateAsync(TEntity model)
    {
    }

    public virtual async Task BeforeUpdateAsync(TEntity model)
    {
    }

    public async Task DeleteAsync(int id)
    {

        var entity = await _dbSet.FirstOrDefaultAsync(i => i.Id == id);

        if (entity == null)
        {
            throw new InvalidIdException();
        }

        using (var dbTransaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
                dbTransaction.Commit();

            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                dbTransaction.Rollback();
                throw;
            }
        }
    }

    public virtual bool Validate(TModel model, ICrudResult validationResuls)
    {
        return true;
    }
}