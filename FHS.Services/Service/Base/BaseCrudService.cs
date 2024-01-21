using DataService.Data;
using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using FHS.Interfaces.Common.Crud;
using FHS.Interfaces.Services.Base;
using FHS.Resources.Logs;
using FHS.Resources.Messages;
using FHS.Interfaces.Mapper.Base;
using Microsoft.EntityFrameworkCore;
using Serilog;

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

    public async Task<TModel?> GetAsync(int id, ICrudResult result)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(i => i.Id == id);

        if (entity == null)
        {
            result.AddMessage(CrudResultMessages.GetAsync_InvalidId);
            return null;
        }

        return _mapper.MapToModel(entity);
    }

    public async Task<IEnumerable<TListModel>> GetAllAsync(ICrudResult result)
    {
        var dbset = await _dbSet.ToListAsync();

        return _mapper.MapToListModels(dbset);
    }


    public async Task CreateAsync(TModel model, ICrudResult result)
    {
        if (model == null)
        {
            result.AddMessage(CrudResultMessages.CreateAsync_InvalidModel);
            return;
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

                _dbSet.Add(entity);
                _dbContext.SaveChanges();

                dbTransaction.Commit();
            }

            catch (Exception ex)
            {
                dbTransaction.Rollback();
                _logger.Error(LogMessage.Error_BaseCrudService_CreateAsync, ex);
                throw;
            }
        }
    }

    public async Task UpdateAsync(int id, TModel model, ICrudResult result)
    {
        if (model == null)
        {
            result.AddMessage(CrudResultMessages.UpdateAsync_InvalidModel);
            return;
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

                await BeforeUpdateAsync(entity);

                entity.Id = id;
                _dbSet.Attach(entity);
                _dbSet.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();

                dbTransaction.Commit();
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
        model.CratedDate = DateTime.Now;
    }

    public virtual async Task BeforeUpdateAsync(TEntity model)
    {
        model.UpdatedDate = DateTime.Now;
    }

    public async Task DeleteAsync(int id, ICrudResult result)
    {

        var entity = await _dbSet.FirstOrDefaultAsync(i => i.Id == id);

        if (entity == null)
        {
            result.AddMessage(CrudResultMessages.DeleteAsync_InvalidId);
            return;
        }

        using (var dbTransaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                BeforeDeleteAsync(id, result);

                _dbSet.Remove(entity);
                _dbContext.SaveChanges();
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

    public virtual void BeforeDeleteAsync(int id, ICrudResult result)
    {
    }

    public virtual bool Validate(TModel model, ICrudResult validationResuls)
    {
        return true;
    }
}